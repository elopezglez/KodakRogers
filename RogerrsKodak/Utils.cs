using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RogersKodak
{


    public enum RKEffortDuration
    {
        [Description("Less than 6 seconds")]
        LessThan_6_Seconds = 1,
        [Description("Between 6 and 20 seconds")]
        Between_6_And_20_Seconds = 2,
        [Description("Between 20 and 30 seconds")]
        Between_20_And_30_Seconds = 3,
        [Description("More than 30 seconds")]
        MoreThan_30_Seconds = 4
    }


    public enum RKEndResult
    {
        [Description("Aceptable")]
        Aceptable = 1,
        [Description("Requiere Atencion")]
        Caution = 2,
        [Description("Atencion Inmediata")]
        Dangerous = 3,
        [Description("Mortal")]
        Mortal = 4
    }

    public enum RKSingleResult
    {
        [Description("Aceptable")]
        Aceptable = 1,
        [Description("Riesgo")]
        Caution = 2,
        [Description("Alto Riesgo")]
        Dangerous = 3,
        [Description("Mortal")]
        Mortal = 4
    }


    public enum RKBodyPart
    {
        Neck,
        Shoulder,
        Back,
        Leg,
        Feet
    }


    public class RKUtils
    {
        private static string[] _lowCombinationCases = { "111", "112", "113", "211", "121", "212", "311", "122", "131", "221" };
        private static string[] _mediumCombinationCases = { "123", "132", "213", "222", "231", "232", "312" };
        private static string[] _highCombinationCases = { "223", "313", "321", "322" };
        // If the combination contains at even one four also its very high "4xx","x4x","xx4"                                                 
        //I added the 333 combination, ask to alberto
        private static string[] _veyHighCombinationCases = { "323", "331", "332", "333" };

        private static readonly Dictionary<string, string> _frequencyOptions = new Dictionary<string, string>
        {
            {"1", "1 por Min"},
            {"2", "De 1 a 5 por Min"},
            {"3","De 5 a 15 por Min"},
            {"4","Mas de 15 por Min"}
        };

        private static readonly Dictionary<string, string> _durationOptions = new Dictionary<string, string> 
        {
            {"1", "Menos de 6 Seg"},
            {"2", "De 6 a 20 Seg"},
            {"3","De 20 a 30 Seg"},
            {"4","Mas de 30 Seg"}
        };

        private static readonly Dictionary<string, string> _levelOptions = new Dictionary<string, string> 
        {
            {"1", "Lijero"},
            {"2", "Moderado"},
            {"3","Pesado"},
            {"4","Muy Pesado"}
        };


        private static RKSingleResult GetResultScore(string pInput)
        {
            foreach (var item in _lowCombinationCases)
            {
                if (item == pInput)
                    return RKSingleResult.Aceptable;
            }

            foreach (var item in _mediumCombinationCases)
            {
                if (item == pInput)
                    return RKSingleResult.Aceptable;
            }

            foreach (var item in _highCombinationCases)
            {
                if (item == pInput)
                    return RKSingleResult.Aceptable;
            }

            foreach (var item in _veyHighCombinationCases)
            {
                if (item.Contains('4') || item == pInput)
                    return RKSingleResult.Aceptable;
            }

            return RKSingleResult.Aceptable;
        }

        #region These methods fill feed dialog controls

        public static void LoadEffortOptions(Form selectDlg)
        {
            var gb = (GroupBox)selectDlg.Controls["gb"];
            var cbLev = (ComboBox)FindControlByKey("level1", gb.Controls);
            cbLev.ValueMember = "Key";
            cbLev.DisplayMember = "Value";
            cbLev.DataSource = new BindingSource(_levelOptions, null);

            var cbDur = (ComboBox)FindControlByKey("duration1", gb.Controls);
            cbDur.ValueMember = "Key";
            cbDur.DisplayMember = "Value";
            cbDur.DataSource = new BindingSource(_durationOptions, null);

            var cbFreq = (ComboBox)FindControlByKey("frequency1", gb.Controls);
            cbFreq.ValueMember = "Key";
            cbFreq.DisplayMember = "Value";
            cbFreq.DataSource = new BindingSource(_frequencyOptions, null);

            if (FindControlByKey("level2", gb.Controls) == null)
                return;

            var cbLev2 = (ComboBox)FindControlByKey("level2", gb.Controls);
            cbLev2.ValueMember = "Key";
            cbLev2.DisplayMember = "Value";
            cbLev2.DataSource = new BindingSource(_levelOptions, null);

            var cbDur2 = (ComboBox)FindControlByKey("duration2", gb.Controls);
            cbDur2.ValueMember = "Key";
            cbDur2.DisplayMember = "Value";
            cbDur2.DataSource = new BindingSource(_durationOptions, null);

            var cbFreq2 = (ComboBox)FindControlByKey("frequency2", gb.Controls);
            cbFreq2.ValueMember = "Key";
            cbFreq2.DisplayMember = "Value";
            cbFreq2.DataSource = new BindingSource(_frequencyOptions, null);
        }

        public static void SetSelectedEffortOption(GroupBox gbSelect, GroupBox gbResults)
        {
            Label lev1 = (Label)FindControlByKey("level1", gbResults.Controls);
            ComboBox cbLev1 = (ComboBox)FindControlByKey("level1", gbSelect.Controls);
            Label dur1 = (Label)FindControlByKey("duration1", gbResults.Controls);
            ComboBox cbDur1 = (ComboBox)FindControlByKey("duration1", gbSelect.Controls);
            Label freq1 = (Label)FindControlByKey("frequency1", gbResults.Controls);
            ComboBox cbFreq1 = (ComboBox)FindControlByKey("frequency1", gbSelect.Controls);
            SetSelectedOptionToCombo(cbLev1, lev1);
            SetSelectedOptionToCombo(cbDur1, dur1);
            SetSelectedOptionToCombo(cbFreq1, freq1);

            if (FindControlByKey("level2", gbSelect.Controls) == null)
                return;

            Label lev2 = (Label)FindControlByKey("level2", gbResults.Controls);
            ComboBox cbLev2 = (ComboBox)FindControlByKey("level2", gbSelect.Controls);
            Label dur2 = (Label)FindControlByKey("duration2", gbResults.Controls);
            ComboBox cbDur2 = (ComboBox)FindControlByKey("duration2", gbSelect.Controls);
            Label freq2 = (Label)FindControlByKey("frequency2", gbResults.Controls);
            ComboBox cbFreq2 = (ComboBox)FindControlByKey("frequency2", gbSelect.Controls);
            SetSelectedOptionToCombo(cbLev2, lev2);
            SetSelectedOptionToCombo(cbDur2, dur2);
            SetSelectedOptionToCombo(cbFreq2, freq2);

        }

        private static void SetSelectedOptionToCombo(ComboBox cbSelect, Label lbResult)
        {
            switch (lbResult.ForeColor.Name)
            {
                case "Black":
                    cbSelect.SelectedValue = "4";
                    break;
                case "Red":
                    cbSelect.SelectedValue = "3";
                    break;
                case "DarkOrange":
                    cbSelect.SelectedValue = "2";
                    break;
                case "LimeGreen":
                    cbSelect.SelectedValue = "1";
                    break;
                default:
                    break;
            }
        }

        public static string GetNumberFromColorName(string colorName)
        {
            string res = "0";
            switch (colorName)
            {
                case "Black":
                    res = "4";
                    break;
                case "Red":
                    res = "3";
                    break;
                case "DarkOrange":
                    res = "2";
                    break;
                case "LimeGreen":
                    res = "1";
                    break;
                default:
                    break;
            }
            return res;
        }

        #endregion

        #region Calculate body-part controls result
        public static void CalculateBodyPartResult(GroupBox gbResults, GroupBox gbSelect)
        {
            Label lev1 = (Label)FindControlByKey("level1", gbResults.Controls);
            Label dur1 = (Label)FindControlByKey("duration1", gbResults.Controls);
            Label freq1 = (Label)FindControlByKey("frequency1", gbResults.Controls);
            Label res1 = (Label)FindControlByKey("result1", gbResults.Controls);
            Label res0 = (Label)FindControlByKey("result0", gbResults.Controls);


            ComboBox cblev1 = (ComboBox)FindControlByKey("level1", gbSelect.Controls);
            ComboBox cbdur1 = (ComboBox)FindControlByKey("duration1", gbSelect.Controls);
            ComboBox cbfreq1 = (ComboBox)FindControlByKey("frequency1", gbSelect.Controls);
            string set1 = cblev1.SelectedValue.ToString() + cbdur1.SelectedValue.ToString() + cbfreq1.SelectedValue.ToString();

            SetSelectedEffortColor(lev1, cblev1);
            SetSelectedEffortColor(dur1, cbdur1);
            SetSelectedEffortColor(freq1, cbfreq1);

            if (FindControlByKey("level2", gbResults.Controls) == null)
            {
                SetSingleResultByEffortCombination(set1, string.Empty, res0, res1, null);
                return;
            }

            Label lev2 = (Label)FindControlByKey("level2", gbResults.Controls);
            Label dur2 = (Label)FindControlByKey("duration2", gbResults.Controls);
            Label freq2 = (Label)FindControlByKey("frequency2", gbResults.Controls);
            Label res2 = (Label)FindControlByKey("result2", gbResults.Controls);

            ComboBox cblev2 = (ComboBox)FindControlByKey("level2", gbSelect.Controls);
            ComboBox cbdur2 = (ComboBox)FindControlByKey("duration2", gbSelect.Controls);
            ComboBox cbfreq2 = (ComboBox)FindControlByKey("frequency2", gbSelect.Controls);
            string set2 = cblev2.SelectedValue.ToString() + cbdur2.SelectedValue.ToString() + cbfreq2.SelectedValue.ToString();

            SetSelectedEffortColor(lev2, cblev2);
            SetSelectedEffortColor(dur2, cbdur2);
            SetSelectedEffortColor(freq2, cbfreq2);
            SetSingleResultByEffortCombination(set1, set2, res0, res1, res2);
        }

        public static string GetBodyPartCombination(GroupBox gb)
        {
            string res = "";
            res += GetNumberFromColorName(((Label)FindControlByKey("level1", gb.Controls)).ForeColor.Name);
            res += GetNumberFromColorName(((Label)FindControlByKey("duration1", gb.Controls)).ForeColor.Name);
            res += GetNumberFromColorName(((Label)FindControlByKey("frequency1", gb.Controls)).ForeColor.Name);
            res += GetNumberFromColorName(((Label)FindControlByKey("result1", gb.Controls)).ForeColor.Name);

            if (FindControlByKey("level2", gb.Controls) == null)
            {
                res += "-" + GetNumberFromColorName(((Label)FindControlByKey("result0", gb.Controls)).BackColor.Name);
                return res;
            }

            res += "-" + GetNumberFromColorName(((Label)FindControlByKey("level2", gb.Controls)).ForeColor.Name);
            res += GetNumberFromColorName(((Label)FindControlByKey("duration2", gb.Controls)).ForeColor.Name);
            res += GetNumberFromColorName(((Label)FindControlByKey("frequency2", gb.Controls)).ForeColor.Name);
            res += GetNumberFromColorName(((Label)FindControlByKey("result2", gb.Controls)).ForeColor.Name);
            res += "-" + GetNumberFromColorName(((Label)FindControlByKey("result0", gb.Controls)).BackColor.Name);
            return res;
        }

        static private void SetSingleResultByEffortCombination(string combination1, string combination2, Label res0, Label res1, Label res2)
        {
            RKSingleResult singleRes1 = RKSingleResult.Aceptable;
            singleRes1 = GetEffortResult(combination1);
            SetSingleResultStyle(res1, singleRes1);

            RKSingleResult singleRes2 = RKSingleResult.Aceptable;
            if (!string.IsNullOrEmpty(combination2))
            {
                singleRes2 = GetEffortResult(combination2);
                SetSingleResultStyle(res2, singleRes2);
            }

            SetEndResultStyle(res0, singleRes1 > singleRes2 ? singleRes1 : singleRes2);
        }


        static private void SetSingleResultStyle(Label lbl, RKSingleResult result)
        {
            switch (result)
            {
                case RKSingleResult.Aceptable:
                    lbl.ForeColor = Color.LimeGreen;
                    lbl.Text = GetEnumDescription(RKSingleResult.Aceptable);
                    break;
                case RKSingleResult.Caution:
                    lbl.ForeColor = Color.DarkOrange;
                    lbl.Text = GetEnumDescription(RKSingleResult.Caution);
                    break;
                case RKSingleResult.Dangerous:
                    lbl.ForeColor = Color.Red;
                    lbl.Text = GetEnumDescription(RKSingleResult.Dangerous);
                    break;
                case RKSingleResult.Mortal:
                    lbl.ForeColor = Color.Black;
                    lbl.Text = GetEnumDescription(RKSingleResult.Mortal);
                    break;
                default:
                    break;
            }
        }

        static private void SetEndResultStyle(Label lblRes, RKSingleResult result)
        {
            lblRes.ForeColor = Color.Black;
            switch (result)
            {
                case RKSingleResult.Aceptable:
                    lblRes.BackColor = Color.LimeGreen;
                    lblRes.Text = GetEnumDescription(RKEndResult.Aceptable);
                    break;
                case RKSingleResult.Caution:
                    lblRes.BackColor = Color.DarkOrange;
                    lblRes.Text = GetEnumDescription(RKEndResult.Caution);
                    break;
                case RKSingleResult.Dangerous:
                    lblRes.BackColor = Color.Red;
                    lblRes.Text = GetEnumDescription(RKEndResult.Dangerous);
                    break;
                case RKSingleResult.Mortal:
                    lblRes.BackColor = Color.Black;
                    lblRes.ForeColor = Color.White;
                    lblRes.Text = GetEnumDescription(RKEndResult.Mortal);
                    break;
                default:
                    break;
            }

        }



        /// <summary>
        /// Determines whether a given combintion is Mortal result
        /// </summary>
        /// <param name="combination"></param>
        /// <returns></returns>
        static private RKSingleResult GetEffortResult(string combination)
        {
            RKSingleResult res = RKSingleResult.Aceptable;
            if (combination.Contains("4"))
                res = RKSingleResult.Mortal;

            else if (_veyHighCombinationCases.Any(a => a == combination))
                res = RKSingleResult.Mortal;

            else if (_highCombinationCases.Any(a => a == combination))
                res = RKSingleResult.Dangerous;

            else if (_mediumCombinationCases.Any(a => a == combination))
                res = RKSingleResult.Caution;

            return res;
        }

        /// <summary>
        /// Find the label by key and return a label control
        /// </summary>
        /// <param name="controlKey">control name</param>
        /// <param name="controls">list of controls</param>
        /// <returns></returns>
        static public Control FindControlByKey(string controlKey, Control.ControlCollection controls)
        {
            Control ctrl = controls.Cast<Control>().Where(a => a.Name.ToLower().Contains(controlKey.ToLower())).FirstOrDefault();
            return ctrl;
        }

        /// <summary>
        /// Manage the label depending of the effort option selected1
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="cmb"></param>
        static private void SetSelectedEffortColor(Label lbl, ComboBox cmb)
        {
            lbl.Text = cmb.Text;
            switch (cmb.SelectedValue.ToString())
            {
                case "1":
                    lbl.ForeColor = Color.LimeGreen;
                    break;
                case "2":
                    lbl.ForeColor = Color.DarkOrange;
                    break;
                case "3":
                    lbl.ForeColor = Color.Red;
                    break;
                case "4":
                    lbl.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }
        }
        #endregion

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

    }
}
