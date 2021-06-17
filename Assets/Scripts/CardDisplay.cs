using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour {

	public Card card;

	public TMP_Text nameText;
	public TMP_Text descriptionText;

	public Image artworkImage;

	public TMP_Text manaText;
	public TMP_Text attackText;
	public TMP_Text healthText;

	void Start () {
		nameText.text = card.name;
		descriptionText.text = card.description;

		artworkImage.sprite = card.artwork;

		manaText.text = card.manaCost.ToString();
		attackText.text = card.attack.ToString();
		healthText.text = card.health.ToString();
        StartCoroutine(DownloadImage("https://picsum.photos/200/300"));
        
	}

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            artworkImage.overrideSprite = sprite;
        }
    }
}
