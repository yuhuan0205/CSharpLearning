using CalculatorAPI.Interfaces;

namespace CalculatorAPI.States
{
    /// <summary>
    /// DivideState is a state inherit OperatingState.
    /// </summary>
    public class DivideState : OperatingState
    {
        /// <summary>
        /// a object store data.
        /// </summary>
        private IMemory Memory;

        /// <summary>
        /// a int store how many times the zeroBtn is clicked.
        /// </summary>
        private int ZeroCount;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="memory"> DI memory </param>
        public DivideState(IMemory memory) : base(memory)
        {
            Memory = memory;
            ZeroCount = Consts.ZERO;
        }

        /// <summary>
        /// add zero into digits, record the times zeroBtn clicked.
        /// </summary>
        /// <returns> this state. </returns>
        public override IState AddDigitZero()
        {
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            ZeroCount++;
            return this;
        }

        /// <summary>
        /// in DivideState, if user add other operators after typed zero, then change state to ErrorState.
        /// </summary>
        /// <param name="element"> operators except divide. </param>
        /// <returns> ErrorState </returns>
        public override IState AddOperator(IElement element)
        {
            for (; ZeroCount == Consts.ZERO; )
            {
                Memory.RemoveLastOperator();
                Memory.AddElement(element);
                return new OperatingState(Memory);
            }
            Memory.ClearCalculatedProcess();
            Memory.SetDigits(Consts.DIVIDE_BY_ZERO_ERROR);
            return new ErrorState(Memory);
        }

        /// <summary>
        /// add divide into expression.
        /// </summary>
        /// <param name="element"> divide. </param>
        /// <returns> this state </returns>
        public override IState AddOperatorDivide(IElement element)
        {
            return this;
        }

        /// <summary>
        /// triggered when user type / and then type zero then type =. 
        /// </summary>
        /// <param name="computeEnging"> a computingEngine </param>
        /// <returns> ErrorState </returns>
        public override IState GetResult(IEngine computeEnging)
        {
            for (; ZeroCount == Consts.ZERO;)
            {
                return base.GetResult(computeEnging);
            }
            Memory.ClearCalculatedProcess();
            Memory.SetDigits(Consts.DIVIDE_BY_ZERO_ERROR);
            return new ErrorState(Memory);
        }
    }
}