
using RogersKodak.Properties;
using System.Drawing;
using System.Windows.Forms;
namespace RogersKodak.Utils
{
    public  static class UIUtils
    {


         public static void SetIconToButton(Button btn,Bitmap img )
         {
             btn.TextImageRelation = TextImageRelation.ImageBeforeText;
             btn.Image = img;           
         }

    }
}
