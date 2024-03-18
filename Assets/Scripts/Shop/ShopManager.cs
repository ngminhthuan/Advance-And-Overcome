using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject CharacterShop;
    [SerializeField] GameObject DiamondShop;

    [Header("Character")]
    [SerializeField] CharactersDatabase characterDataBase;
    [SerializeField] Image characterSprite;
    [SerializeField] Text characterName;
    [SerializeField] int currentIDCharShop;

    [SerializeField] GameObject PreviosBtn;
    [SerializeField] GameObject NextBtn;
    [SerializeField] GameObject SelectBtn;
    [SerializeField] GameObject SelectedBtn;
    [SerializeField] GameObject BuyBtn;
    [SerializeField] Text DiamondUserCharShop;

    [Header("Diamond Shop")]
    [SerializeField] Text DiamondUserDiamondShop;

    #region Character Shop

    public void initCharacter()
    {
        currentIDCharShop = 0;
        SetCharacterInfoShop();
    }

    public void PreviosCharacter()
    {
        currentIDCharShop -= 1;
        if (currentIDCharShop <= 0)
        {
            PreviosBtn.SetActive(false);
        }
        SetCharacterInfoShop();
    }
    public void OnPurchaseCharacter()
    {
        
    }
    public void NextCharacter()
    {
        currentIDCharShop += 1;
        if (currentIDCharShop >= characterDataBase.CharactersCount)
        {
            NextBtn.SetActive(false);
        }
        SetCharacterInfoShop();
    }

    public void SelectedNewCharacter()
    {
        PlayerGameData.Instance.UseNewCharacter(currentIDCharShop);
        SetActiveBtnCharacterCustom(true, true);
    }

    public void SetCharacterInfoShop()
    {
        Character characterShop = characterDataBase.GetCharacterByID(currentIDCharShop);
        characterSprite.sprite = characterShop.characterSprite;
        characterName.text = characterShop.characterName;

        if (PlayerGameData.Instance.PlayerData.currentCharacter == currentIDCharShop)
        {
            SetActiveBtnCharacterCustom(true, true);
        }
        else
        {
            if(PlayerGameData.Instance.PlayerData.listCharacterID.Contains(currentIDCharShop))
            {
                SetActiveBtnCharacterCustom(false, true);
            }
            else
            {
                SetActiveBtnCharacterCustom();
            }
        }
    }

    public void SetActiveBtnCharacterCustom(bool isSelected = false, bool isBougth = false)
    {
        if(!isBougth)
        {
            SelectBtn.SetActive(false);
            SelectedBtn.SetActive(false);
            BuyBtn.SetActive(true);
        }
        else
        {
            SelectedBtn.SetActive(isSelected);
            SelectBtn.SetActive(!isSelected);
            BuyBtn.SetActive(false);
        }
    }

    public void OnClickHideCharacterShop()
    {
        CharacterShop.SetActive(false);

    }

    public void OnClickShowCharacterShop()
    {
        initCharacter();
        CharacterShop.SetActive(true);
    }
    #endregion

    #region Diamond Shop
    public void OnPurchaseDiamond(int amount)
    {
        PlayerGameData.Instance.AddDimond(amount);
    }

    public void OnClickHideDiamondShop()
    {
        DiamondShop.SetActive(false);
        
    }
    public void OnClickShowDiamondShop()
    {
        DiamondShop.SetActive(true);
    }
    
    #endregion
}
