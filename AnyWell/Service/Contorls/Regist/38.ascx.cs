﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Contorls_Regist_38 : UserControlBase
{
    protected void Page_Load( object sender, EventArgs e )
    {

    }

    private AW_Regist_bean _bean;
    public AW_Regist_bean bean
    {
        get
        {
            if( _bean == null )
            {
                _bean = ( AW_Regist_bean ) Context.Items[ "Context_Regist" ];
            }
            return _bean;
        }
        set
        {
            _bean = value;
        }
    }

    public string getCountry()
    {
        switch( bean.fdRegiCountry )
        {
            case 93:
                return "Afghanistan";
            case 355:
                return "Albania";
            case 213:
                return "Algeria";
            case 376:
                return "Andorra";
            case 244:
                return "Angola";
            case 1264:
                return "Anguilla";
            case 54:
                return "Argentina";
            case 374:
                return "Armenia";
            case 297:
                return "Aruba";
            case 247:
                return "AscensionIsland";
            case 61:
                return "Australia";
            case 43:
                return "Austria";
            case 994:
                return "Azerbaijan";
            case 1242:
                return "Bahamas";
            case 973:
                return "Bahrain";
            case 880:
                return "Bangladesh";
            case 1246:
                return "Barbados";
            case 375:
                return "Belarus";
            case 32:
                return "Belgium";
            case 501:
                return "Belize";
            case 229:
                return "Benin";
            case 1441:
                return "Bermuda";
            case 975:
                return "Bhutan";
            case 591:
                return "Bolivia";
            case 387:
                return "BosniaAndHerzegovina";
            case 267:
                return "Botswana";
            case 55:
                return "Brazil";
            case 673:
                return "Brunei";
            case 359:
                return "Bulgaria";
            case 226:
                return "BurkinaFaso";
            case 95:
                return "Burma";
            case 257:
                return "Burundi";
            case 855:
                return "Cambodia";
            case 237:
                return "Cameroon";
            case 10:
                return "Canada";
            case 238:
                return "CapeVerde";
            case 1345:
                return "CaymanIslands";
            case 236:
                return "CentralAfricanRepublic";
            case 235:
                return "Chad";
            case 86:
                return "China";
            case 56:
                return "Chile";
            case 57:
                return "Colombia";
            case 269:
                return "Comoros";
            case 242:
                return "Congo";
            case 682:
                return "CookIslands";
            case 506:
                return "CostaRica";
            case 385:
                return "Croatia";
            case 53:
                return "Cuba";
            case 357:
                return "Cyprus";
            case 420:
                return "CzechRepublic";
            case 45:
                return "Denmark";
            case 253:
                return "Djibouti";
            case 1767:
                return "Dominica";
            case 1809:
                return "DominicanRepublic";
            case 593:
                return "Ecuador";
            case 20:
                return "Egypt";
            case 503:
                return "ElSalvador";
            case 240:
                return "EquatorialGuinea";
            case 291:
                return "Eritrea";
            case 372:
                return "Estonia";
            case 251:
                return "Ethiopia";
            case 500:
                return "FalklandIslands";
            case 679:
                return "Fiji";
            case 358:
                return "Finland";
            case 33:
                return "France";
            case 594:
                return "FrenchGuiana";
            case 241:
                return "Gabon";
            case 220:
                return "Gambia";
            case 995:
                return "Georgia";
            case 49:
                return "Germany";
            case 233:
                return "Ghana";
            case 350:
                return "Gibraltar";
            case 30:
                return "Greece";
            case 299:
                return "Greenland";
            case 1473:
                return "Grenada";
            case 1671:
                return "Guam";
            case 502:
                return "Guatemala";
            case 224:
                return "Guinea";
            case 245:
                return "Guinea-Bissau";
            case 592:
                return "Guyana";
            case 509:
                return "Haiti";
            case 852:
                return "Hong Kong（SAR)";
            case 504:
                return "Honduras";
            case 36:
                return "Hungary";
            case 354:
                return "Iceland";
            case 91:
                return "India";
            case 62:
                return "Indonesia";
            case 98:
                return "Iran";
            case 964:
                return "Iraq";
            case 353:
                return "Ireland";
            case 972:
                return "Israel";
            case 39:
                return "Italy";
            case 225:
                return "IvoryCoast";
            case 1876:
                return "Jamaica";
            case 81:
                return "Japan";
            case 962:
                return "Jordan";
            case 7:
                return "Kazakhstan";
            case 254:
                return "Kenya";
            case 686:
                return "Kiribati";
            case 82:
                return "Korea";
            case 965:
                return "Kuwait";
            case 996:
                return "Kyrgyzstan";
            case 856:
                return "Laos";
            case 371:
                return "Latvia";
            case 961:
                return "Lebanon";
            case 266:
                return "Lesotho";
            case 231:
                return "Liberia";
            case 218:
                return "Libya";
            case 423:
                return "Liechtenstein";
            case 370:
                return "Lithuania";
            case 352:
                return "Luxembourg";
            case 853:
                return "Macao（SAR)";
            case 389:
                return "Macedonia";
            case 261:
                return "Madagascar";
            case 265:
                return "Malawi";
            case 60:
                return "Malaysia";
            case 960:
                return "Maldives";
            case 223:
                return "Mali";
            case 356:
                return "Malta";
            case 670:
                return "MarianaIs.";
            case 692:
                return "MarshallIs.";
            case 596:
                return "Martinique";
            case 222:
                return "Mauritania";
            case 230:
                return "Mauritius";
            case 270:
                return "MayotteI.";
            case 52:
                return "Mexico";
            case 373:
                return "Moldova";
            case 377:
                return "Monaco";
            case 976:
                return "Mongolia";
            case 1664:
                return "Montserrat";
            case 212:
                return "Morocco";
            case 258:
                return "Mozambique";
            case 264:
                return "Namibia";
            case 674:
                return "Nauru";
            case 977:
                return "Nepal";
            case 31:
                return "Netherlands";
            case 64:
                return "NewZealand";
            case 505:
                return "Nicaragua";
            case 227:
                return "Niger";
            case 234:
                return "Nigeria";
            case 683:
                return "Niue";
            case 672:
                return "NorfolkIsland";
            case 850:
                return "NorthKorea";
            case 47:
                return "Norway";
            case 968:
                return "Oman";
            case 92:
                return "Pakistan";
            case 507:
                return "Panama";
            case 675:
                return "PapuaNewGuinea";
            case 595:
                return "Paraguay";
            case 51:
                return "Peru";
            case 63:
                return "Philippines";
            case 48:
                return "Poland";
            case 351:
                return "Portugal";
            case 1787:
                return "PuertoRico";
            case 974:
                return "Qatar";
            case 262:
                return "ReunionI.";
            case 40:
                return "Roumania";
            case 8:
                return "Russia";
            case 250:
                return "Rwanda";
            case 685:
                return "Samoa";
            case 378:
                return "San.Marino";
            case 966:
                return "SaudiArabia";
            case 221:
                return "Senegal";
            case 248:
                return "Seychelles";
            case 232:
                return "SierraLeone";
            case 65:
                return "Singapore";
            case 421:
                return "Slovakia";
            case 386:
                return "Slovenia";
            case 677:
                return "SolomonIslands";
            case 252:
                return "Somalia";
            case 27:
                return "SouthAfrica";
            case 34:
                return "Spain";
            case 94:
                return "SriLanka";
            case 290:
                return "St.Helena";
            case 1758:
                return "St.Lucia";
            case 249:
                return "Sudan";
            case 597:
                return "Suriname";
            case 268:
                return "Swaziland";
            case 46:
                return "Sweden";
            case 41:
                return "Switzerland";
            case 963:
                return "Syria";
            case 886:
                return "Taiwan China";
            case 255:
                return "Tanzania";
            case 66:
                return "Thailand";
            case 228:
                return "Togo";
            case 690:
                return "TokelauIs.";
            case 676:
                return "Tonga";
            case 216:
                return "Tunisia";
            case 90:
                return "Turkey";
            case 993:
                return "Turkmenistan";
            case 688:
                return "Tuvalu";
            case 971:
                return "U.A.E.";
            case 256:
                return "Uganda";
            case 380:
                return "Ukraine";
            case 44:
                return "UnitedKingdom";
            case 1:
                return "UnitedStates";
            case 598:
                return "Uruguay";
            case 998:
                return "Uzbekistan";
            case 678:
                return "Vanuatu";
            case 379:
                return "Vatican";
            case 58:
                return "Venezuela";
            case 84:
                return "Vietnam";
            case 1808:
                return "WakeI.";
            case 967:
                return "Yemen";
            case 381:
                return "Yugoslavia";
            case 243:
                return "Zaire";
            case 260:
                return "Zambia";
            case 263:
                return "Zimbabwe";
            default:
                return "";
        }
    }
}
