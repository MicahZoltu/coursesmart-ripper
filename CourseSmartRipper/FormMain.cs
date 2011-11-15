using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Timers;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CourseSmartRipper
{
	public partial class FormMain : Form
	{
		CookieContainer mCookies = new CookieContainer();
		FileStream mOutputFile;
		StreamWriter mOutputFileWriter;
		static String mOutputDirectory = "CourseSmartImages";
		String mOutputPath;

		String mBaseURL = "www.coursesmart.com";
		String mURLSuffix;
		Int32 mActionCounter = 0;
		String mVersion;
		String mStaticParameters;
		String mDynamicParameters;

		String mNextXmlId;
		String mUsername;
		String mPassword;

		Int32 mDownloadsStarted = 0;
		Int32 mDownloadsFinished = 0;

        Random mRandomTime = new Random();
		System.Timers.Timer mTimer = new System.Timers.Timer(20000);

		public FormMain()
		{
			InitializeComponent();
		}

		protected override void OnFormClosing(FormClosingEventArgs pEventArgs)
		{
			mOutputFileWriter.Close();

			base.OnFormClosing(pEventArgs);
		}

		private void buttonStart_Click(object pSender, EventArgs pEventArgs)
		{
			saveFileDialog.ShowDialog();
		}

		private void saveFileDialog_FileOk(object pSender, CancelEventArgs pEventArgs)
		{
			if (mOutputFile != null)
			{
				mOutputFile.Close();
				mOutputFile = null;
			}

			mOutputDirectory = textBoxBookNumber.Text;
			mOutputFile = saveFileDialog.OpenFile() as FileStream;
			mOutputFileWriter = new StreamWriter(mOutputFile);
			mOutputPath = Path.GetDirectoryName(mOutputFile.Name) + "\\" + mOutputDirectory + "\\";
			Directory.CreateDirectory(mOutputPath);

			mNextXmlId = textBoxBookNumber.Text + "/" + textBoxStartingPage.Text;
			mUsername = textBoxUsername.Text;
			mPassword = textBoxPassword.Text;

			mTimer.Elapsed += new ElapsedEventHandler(OnTimerExpired);
			mTimer.Enabled = false;
			mTimer.AutoReset = false;

            LoginRequest();
		}

		private void LoginRequest()
		{
			// Update the UI.
			WriteLine("Logging in...");

			// Build the URL.
			String lURL = "http://www.coursesmart.com/login?__formName=formlogin&__login=" + mUsername + "&__password=" + mPassword;
			
			// Build the login request.
			HttpWebRequest lRequest = (HttpWebRequest)WebRequest.Create(lURL);
			lRequest.CookieContainer = mCookies;
			lRequest.Method = "GET";
			lRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
			
			// Kick off the login attempt.
			lRequest.BeginGetResponse(new AsyncCallback(LoginResponse), lRequest);
		}

		private void LoginResponse(IAsyncResult pResult)
		{
			HttpWebRequest lRequest = pResult.AsyncState as HttpWebRequest;
			using (HttpWebResponse lResponse = lRequest.EndGetResponse(pResult) as HttpWebResponse)
			{

				// The success page is very small (<5000 bytes).  The login failed page is very large (~20,000 bytes).
				if (lResponse.ContentLength > 5000 || lResponse.ContentLength < 0)
				{
					// Update the UI with the authentication failure.
					WriteLine("\tLogin Failed.");
					return;
				}
			}
			// Update the UI.
			WriteLine("\tLogin Success!");

			// Restart the action counter.
			mActionCounter = 0;

			// Kick off the request for the first page.
			FirstPageRequest();
		}

		private void FirstPageRequest()
		{
			// Build the URL
			String lURL = "http://" + mBaseURL + "/" + mNextXmlId;

			WriteLine("Requesting first page: " + lURL);

			// Build the web request
			HttpWebRequest lRequest = WebRequest.Create(lURL) as HttpWebRequest;
			lRequest.CookieContainer = mCookies;
			lRequest.Method = "GET";
			lRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";

			// Kick off the request
			lRequest.BeginGetResponse(new AsyncCallback(FirstPageResponse), lRequest);
		}

		private void FirstPageResponse(IAsyncResult pResult)
		{
			WriteLine("\tFirst page received!");

			HttpWebRequest lRequest = pResult.AsyncState as HttpWebRequest;
			String lResponseString;
			using (HttpWebResponse lResponse = lRequest.EndGetResponse(pResult) as HttpWebResponse)
			{
				using (Stream lResponseStream = lResponse.GetResponseStream())
				{
					lResponseString = new StreamReader(lResponseStream).ReadToEnd();
				}
			}

			Match lMatch = Regex.Match(lResponseString, "var A={B:.*E:'(?<xml_id>[^']*)'.*J:'(?<version>[^']*)'.*N:'(?<base_url>[^']*)'");
			String lXmlID = lMatch.Groups["xml_id"].Value;
			mVersion = lMatch.Groups["version"].Value;
			mBaseURL = lMatch.Groups["base_url"].Value;

			lMatch = Regex.Match(lResponseString, "{'Id':'SectionContent'.*'Url':'(?<url_suffix>[^']*)'.*'StaticParameters':new Array\\('(?<static_parameters>[^']*)'\\).*'DynamicParameters':new Array\\('(?<dynamic_parameters>[^']*)'\\)");
			mURLSuffix = lMatch.Groups["url_suffix"].Value;
			mStaticParameters = lMatch.Groups["static_parameters"].Value;
			mDynamicParameters = lMatch.Groups["dynamic_parameters"].Value;
			
			GetPageRequest(lXmlID);
		}

		private void GetPageRequest(String pXmlID)
		{
			// Build the URL
			Int32 lRandom = new Random().Next(100000000, 999999999);
			String lURL = "http://" + mBaseURL + mURLSuffix + "?__sugus=" + lRandom + "&action=" + ++mActionCounter + "&__version=" + mVersion + "&" + mStaticParameters + "&xmlid=" + pXmlID + "&__imagepageresolution=1000&" + mDynamicParameters;

			WriteLine("Requesting " + pXmlID + "...");

			// Build the web request
			HttpWebRequest lRequest = WebRequest.Create(lURL) as HttpWebRequest;
			lRequest.CookieContainer = mCookies;
			lRequest.Method = "GET";
			lRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";

			// Kick off the request
			lRequest.BeginGetResponse(new AsyncCallback(GetPageResponse), lRequest);
		}

		private void GetPageResponse(IAsyncResult pResult)
		{
			HttpWebRequest lRequest = pResult.AsyncState as HttpWebRequest;
			String lResponseString;
			using (HttpWebResponse lResponse = lRequest.EndGetResponse(pResult) as HttpWebResponse)
			{
				using (Stream lResponseStream = lResponse.GetResponseStream())
				{
					lResponseString = new StreamReader(lResponseStream).ReadToEnd();
				}
			}
			
			Match lMatch = Regex.Match(lResponseString, "<input value=\"(?<xml_id>[^\"]*?)\" type=\"hidden\" name=\"\" id=\"Reader_CurrentXmlId\" />");
			String lCurrentXmlId = lMatch.Groups["xml_id"].Value;
			WriteLine("\tReceived " + lCurrentXmlId);

			// Check to see if we got logged out.
            if (Regex.IsMatch(lResponseString, "<div class=\"reader_preview\">"))
			{
				mNextXmlId = lCurrentXmlId;
				LoginRequest();
				return;
			}

			// Write the starting DIV tag to the output file.
			mOutputFileWriter.WriteLine("<div style=\"position:relative; page-break-after:always; page-break-inside:avoid\">");

			// Grab each of the images out of the response and put them in a list.
			List<ImageInfo> lImages = new List<ImageInfo>();
			Double lTotalHeight = 0;
			Double lTotalWidth = 0;
			lMatch = Regex.Match(lResponseString, "<img.*?width:(?<width>\\d*?)px; height:(?<height>\\d*?)px;.*?src=\"(?<link>http://.*?\\.bvdep\\.com/imagepage/(?<image_name>.*?))\".*?/>");
			while (lMatch.Success)
			{
				// Queue up the image to download.
				GetImageRequest(lMatch.Groups["link"].Value);

				// Convert the extracted strings to numbers.
				Double lImageHeight = Convert.ToDouble(lMatch.Groups["height"].Value);
				Double lImageWidth = Convert.ToDouble(lMatch.Groups["width"].Value);

				// Track the total height/width of all the images on this page.
				lTotalHeight += lImageHeight;
				lTotalWidth = Math.Max(lImageWidth, lTotalWidth);

				// Add the image to our list.
				lImages.Add(new ImageInfo(lImageWidth, lImageHeight, lMatch.Groups["image_name"].Value));

				// Find the next image on this page.
				lMatch = lMatch.NextMatch();
			}

			// Aspect ratio of whole page
			Double lAspectRatio = lTotalWidth / lTotalHeight;

			// Figure out the scaling factors for this page so it fits in *just* under one page (<216 wide and <280 high).
			Double lHeightScaler = 275 / lTotalHeight;
			Double lWidthScalar = 210 / lTotalWidth;
			Double lScalar = Math.Min(lHeightScaler, lWidthScalar);

			// Add the image tags to the output file, applying the scalar along the way.
			foreach (ImageInfo lImageInfo in lImages)
			{
				String lImageWidthString = Convert.ToString(lImageInfo.mWidth * lScalar);
				String lImageHeightString = Convert.ToString(lImageInfo.mHeight * lScalar);
				WriteImage(lImageWidthString, lImageHeightString, lImageInfo.mName);
			}

			// Write the closing div tag and printing page break to the output file.
			mOutputFileWriter.WriteLine("</div>");

			// Get the next page ID.
			lMatch = Regex.Match(lResponseString, "<input value=\"(?<xml_id>[^\"]*?)\" type=\"hidden\" name=\"\" id=\"Reader_NextXmlId\"/>");
			String lXmlID = lMatch.Groups["xml_id"].Value;
			
			// If there is no next page then we are done.
			if (lXmlID == "")
			{
				WriteLine("All done! (wait for any remaining images to download though)");
				mOutputFileWriter.Close();
				return;
			}

			// Get the next page.
			mNextXmlId = lXmlID;
            mTimer.Interval = mRandomTime.Next(15000, 25000);
			mTimer.Start();
		}

		private void OnTimerExpired(Object pSource, System.Timers.ElapsedEventArgs pArguments)
		{
			GetPageRequest(mNextXmlId);
		}

		private void GetImageRequest(String pImageURL)
		{
			// Build the web request
			HttpWebRequest lRequest = WebRequest.Create(pImageURL) as HttpWebRequest;
			lRequest.CookieContainer = mCookies;
			lRequest.Method = "GET";
			lRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";

			WriteLine("\tDownloading " + lRequest.RequestUri.Segments[lRequest.RequestUri.Segments.Length - 1] + "...");
			++mDownloadsStarted;
			UpdateDownloadCounter();

			// Kick off the request
			lRequest.BeginGetResponse(new AsyncCallback(GetImageResponse), lRequest);
		}

		private void GetImageResponse(IAsyncResult pResult)
		{
			HttpWebRequest lRequest = pResult.AsyncState as HttpWebRequest;
			String lImageName = lRequest.RequestUri.Segments[lRequest.RequestUri.Segments.Length - 1];
			using (MemoryStream lImageStream = new MemoryStream())
			{
				using (HttpWebResponse lResponse = lRequest.EndGetResponse(pResult) as HttpWebResponse)
				{
					using (Stream lResponseStream = lResponse.GetResponseStream())
					{
						lResponseStream.CopyTo(lImageStream);
					}
				}

				WriteLine("\t\tDownloaded " + lImageName);
				++mDownloadsFinished;
				UpdateDownloadCounter();

				// Get the image out of the response stream.
				Image lImage = Image.FromStream(lImageStream);

				// Save the image to disk.
				using (FileStream lImageFile = new FileStream(mOutputPath + lImageName + ".jpg", FileMode.Create))
				{
					lImage.Save(lImageFile, System.Drawing.Imaging.ImageFormat.Jpeg);
				}
			}
		}
		
		private void WriteImage(String pWidth, String pHeight, String pSource)
		{
			mOutputFileWriter.WriteLine("\t<img style=\"width:" + pWidth + "mm; height:" + pHeight + "mm; padding:0; margin:0; border:none;\" src=\"" + mOutputDirectory + "/" + pSource + ".jpg\"/>");
		}

		private delegate void WriteLineDelegate(String pString);
		private void WriteLine(String pString)
		{
			if (textBoxOutput.InvokeRequired)
			{
				textBoxOutput.Invoke(new WriteLineDelegate(WriteLine), new Object[] { pString });
			}
			else
			{
				textBoxOutput.AppendText(pString + "\r\n");
			}
		}

		private delegate void UpdateDownloadCounterDelegate();
		private void UpdateDownloadCounter()
		{
			if (textBoxDownloadCounter.InvokeRequired)
			{
				textBoxDownloadCounter.Invoke(new UpdateDownloadCounterDelegate(UpdateDownloadCounter));
			}
			else
			{
				textBoxDownloadCounter.Text = mDownloadsFinished + "/" + mDownloadsStarted;
			}
		}

		private class ImageInfo
		{
			public Double mWidth;
			public Double mHeight;
			public String mName;

			public ImageInfo(Double pWidth, Double pHeight, String pName)
			{
				mWidth = pWidth;
				mHeight = pHeight;
				mName = pName;
			}
		}
	}
}
