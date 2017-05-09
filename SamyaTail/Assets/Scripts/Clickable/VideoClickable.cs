using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoClickable : BaseClickable {

    public VideoPlayer[] videoSourceList;

    private int _indexVideo = 0;

    protected override void _OnClickedObject() {
        for (int i = 0; i < videoSourceList.Length; i++) {
            videoSourceList[i].gameObject.SetActive(true);
        }

        var videoSource = videoSourceList[_indexVideo];
        videoSource.Play();

        StartCoroutine(_CallbackFinishedVideo(videoSource.clip.length));
    }

    private IEnumerator _CallbackFinishedVideo(double time) {
        float timeFloat = (float)time;
        yield return new WaitForSeconds(timeFloat);

        _indexVideo++;

        if (_indexVideo <= (videoSourceList.Length - 1)) {
            var videoSource = videoSourceList[_indexVideo];
            videoSource.Play();
            StartCoroutine(_CallbackFinishedVideo(videoSource.clip.length));
        }
        else {
            _HideVideo();
        }

        yield return null;
    }

    protected override void _OnLeavingObject() {
        StopAllCoroutines();

        _indexVideo = 0;
        _HideVideo();
    }

    private void _HideVideo() {
        for (int i = 0; i < videoSourceList.Length; i++) {
            videoSourceList[i].Stop();
            videoSourceList[i].gameObject.SetActive(false);
        }
    }
}
