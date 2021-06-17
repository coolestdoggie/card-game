using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour {

	[SerializeField] Card card;



	[SerializeField] TMP_Text nameText;
	[SerializeField] TMP_Text descriptionText;
    
	[SerializeField] Image artworkImage;

	[SerializeField] TMP_Text manaText;
	[SerializeField] TMP_Text attackText;
    [SerializeField] TMP_Text healthText;

    float hp;
    float attack;
    float mana;

    public TMP_Text HealthText { get => healthText; set => healthText = value; }

    public float Hp { get => hp; set
        { 
            hp = value;
            HealthText.text = hp.ToString();
        }
    }

    public float Attack { get => attack; set
        {
            attack = value;
            attackText.text = attack.ToString();
        }
    }

    public float Mana { get => mana; set 
        {
            mana = value;
            manaText.text = mana.ToString();
        }
    }

    void Start () {
        Hp = card.health;

		nameText.text = card.name;
		descriptionText.text = card.description;

		artworkImage.sprite = card.artwork;

		manaText.text = Mana.ToString();
		attackText.text = Attack.ToString();
		HealthText.text = Hp.ToString();
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
