using System;
using System.Windows.Controls;

namespace lecture_8_dll_example
{
    public class listBoxExtensions : ListBox
    {
        public string displayValue(ListBox lstBox)
        {
            return "the selected value of the listbox is : " + lstBox.SelectedValue.ToString();
        }
    }
}
