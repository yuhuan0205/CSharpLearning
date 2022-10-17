namespace LittleComputer
{
    using System.Windows.Forms;

    /// <summary>
    /// Abstract Button class.
    /// </summary>
    public abstract class AbstractBtn : Button
    {
        /// <summary>
        /// every child class should implement this abstract function.
        /// it makes each button has its own OnClick function.
        /// </summary>
        public abstract void OnClick(ICalculator calculator);

        
        /// <summary>
        /// button's text. 
        /// </summary>
        public string ButtonText
        {
            get 
            { 
                return this.Text; 
            }

            set
            {
                this.Text = value;
            }
        }
    }
}