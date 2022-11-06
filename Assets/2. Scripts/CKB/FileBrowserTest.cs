using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudio;
using NAudio.Wave;
using SimpleFileBrowser;
using UnityEngine.UI;

public class FileBrowserTest : MonoBehaviour
{
	public static FileBrowserTest instance;
	// Warning: paths returned by FileBrowser dialogs do not contain a trailing '\' character
	// Warning: FileBrowser can only show 1 dialog at a time
	public AudioSource audioSource;
	public GameObject msFactory;
	public Transform msContent;
	byte[] bytes;

	public float[] samples = new float[64];
	public Image ms;
	RectTransform[] bars;
	float[] spectrum = new float[256];

	// 총 프레임 값
	float totalFrame;
	// 스펙트럼 간격
	float spectrumGap;

	// musicwave content
	public GameObject musicWaveContent;

    private void Awake()
    {
		instance = this;
    }
    private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		FixScrollView();
	}

	private void Update()
	{
		//     if(audioSource != null)
		//     {
		//         if (Input.GetKeyDown(KeyCode.Q))
		//         {
		//	audioSource.Play();
		//}
		//     }
	}
	public void ShowFileBrowser()
	{
		// Set filters (optional)
		// It is sufficient to set the filters just once (instead of each time before showing the file browser dialog), 
		// if all the dialogs will be using the same filters
		FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"));

		// Set default filter that is selected when the dialog is shown (optional)
		// Returns true if the default filter is set successfully
		// In this case, set Images filter as the default filter
		FileBrowser.SetDefaultFilter(".jpg");

		// Set excluded file extensions (optional) (by default, .lnk and .tmp extensions are excluded)
		// Note that when you use this function, .lnk and .tmp extensions will no longer be
		// excluded unless you explicitly add them as parameters to the function
		FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");

		// Add a new quick link to the browser (optional) (returns true if quick link is added successfully)
		// It is sufficient to add a quick link just once
		// Name: Users
		// Path: C:\Users
		// Icon: default (folder icon)
		FileBrowser.AddQuickLink("Users", "C:\\Users", null);

		// Show a save file dialog 
		// onSuccess event: not registered (which means this dialog is pretty useless)
		// onCancel event: not registered
		// Save file/folder: file, Allow multiple selection: false
		// Initial path: "C:\", Initial filename: "Screenshot.png"
		// Title: "Save As", Submit button text: "Save"
		// FileBrowser.ShowSaveDialog( null, null, FileBrowser.PickMode.Files, false, "C:\\", "Screenshot.png", "Save As", "Save" );

		// Show a select folder dialog 
		// onSuccess event: print the selected folder's path
		// onCancel event: print "Canceled"
		// Load file/folder: folder, Allow multiple selection: false
		// Initial path: default (Documents), Initial filename: empty
		// Title: "Select Folder", Submit button text: "Select"
		// FileBrowser.ShowLoadDialog( ( paths ) => { Debug.Log( "Selected: " + paths[0] ); },
		//						   () => { Debug.Log( "Canceled" ); },
		//						   FileBrowser.PickMode.Folders, false, null, null, "Select Folder", "Select" );

		// Coroutine example
		StartCoroutine(ShowLoadDialogCoroutine());
	}

	IEnumerator ShowLoadDialogCoroutine()
	{
		// Show a load file dialog and wait for a response from user
		// Load file/folder: both, Allow multiple selection: true
		// Initial path: default (Documents), Initial filename: empty
		// Title: "Load File", Submit button text: "Load"
		yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");

		// Dialog is closed
		// Print whether the user has selected some files/folders or cancelled the operation (FileBrowser.Success)
		Debug.Log(FileBrowser.Success);

		if (FileBrowser.Success)
		{
			// Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
			for (int i = 0; i < FileBrowser.Result.Length; i++)
				Debug.Log(FileBrowser.Result[i]);

			// Read the bytes of the first file via FileBrowserHelpers
			// Contrary to File.ReadAllBytes, this function works on Android 10+, as well
			bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);
			//string str = System.Text.Encoding.UTF8.GetString(bytes);
			string str = System.Text.Encoding.Default.GetString(bytes);

			audioSource.clip = NAudioPlayer.FromMp3Data(bytes);
			MusicWave();
			//audioSource.Play();
			//print(bytes.Length);
			//print(audioSource.clip.length);

			// Or, copy the first file to persistentDataPath
			string destinationPath = Path.Combine(Application.streamingAssetsPath, FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
			FileBrowserHelpers.CopyFile(FileBrowser.Result[0], destinationPath);
		}
	}

	//// 스펙트럼을 만들고 싶다
	//// 스펙트럼은 1프레임마다 막대 하나로 생성하고 싶다
	//public void MusicSpectrum()
	//{
	//	for (int i = 0; i < bytes.Length; i++)
	//	{
	//		GameObject ms = Instantiate(msFactory, msContent);
	//		rtSpectrum = ms.GetComponent<RectTransform>();
	//		msPosX += spectrumGap;
	//		rtSpectrum.anchoredPosition = new Vector2(msPosX, rtSpectrum.anchoredPosition.y);
	//	}

	//}

	// 스펙트럼을 만들고 싶다
	// 총프레임은 audioSource.clip.length에 30을 곱한 값으로 한다
	// 총프레임을 스펙트럼의 갯수(256개)로 나눈 값이 스펙트럼의 간격이다
	public void MusicWave()
	{
		audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
		print(spectrum.Length);
		bars = new RectTransform[spectrum.Length];

		totalFrame = audioSource.clip.length * 30;
		print(totalFrame);
		spectrumGap = totalFrame / 256;
		print(spectrumGap);

        for (int i = 1; i < bars.Length; i++)
        {
            bars[i] = Instantiate(ms).GetComponent<RectTransform>();
            bars[i].parent = msContent;
            bars[i].anchoredPosition = new Vector2(spectrumGap * i, 0);
            bars[i].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, spectrum[i] * 100000000000);
        }

    }

	// 버그로 인한 스크롤뷰의 height를 40으로 고정하고 싶다
	public void FixScrollView()
    {
		RectTransform mwc = musicWaveContent.GetComponent<RectTransform>();
		mwc.anchoredPosition = new Vector2(mwc.anchoredPosition.x, 40);
    }
}
