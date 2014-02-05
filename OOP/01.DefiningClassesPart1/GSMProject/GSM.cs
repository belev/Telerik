using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMProject
{
    //01.Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

    //02.Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

    public class GSM
    {
        private string model;
        private string manufacturer;
        private ushort? price;
        private string owner;
        private Battery batteryCharacteristics;
        private Display displayCharacteristics;
        private List<Call> callHistory = new List<Call>();

        //06.Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.

        private static GSM iPhone4S = new GSM("IPhone4S", "Apple", 1600, "Goshlqka", new Battery("B1398A", BatteryType.NiMH), new Display(4.8M, 2000000));

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;

            this.price = null;
            this.owner = null;
            this.batteryCharacteristics = new Battery();
            this.displayCharacteristics = new Display();
        }

        public GSM(string model, string manufacturer, ushort? price)
            : this(model, manufacturer)
        {
            this.Price = price;
        }

        public GSM(string model, string manufacturer, ushort? price, string owner, Battery batteryChar, Display displayChar)
            : this(model, manufacturer, price)
        {
            this.Owner = owner;
            this.batteryCharacteristics = new Battery(batteryChar);
            this.displayCharacteristics = new Display(displayChar);
        }

        //05.Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. Ensure all fields hold correct data at any given time.

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The model can't be null or empty! Enter a valid model!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The manufacturer can't be null or empty! Enter a valid manufacturer!");
                }
                this.manufacturer = value;
            }
        }

        public ushort? Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price of the phone can't be negative!");
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The owner can't be null or empty! Enter a valid manufacturer!");
                }
                this.owner = value;
            }
        }

        public Battery BatteryCharacteristics
        {
            get { return this.batteryCharacteristics; }
        }

        public Display DisplayCharacteristics
        {
            get { return this.displayCharacteristics; }
        }

        //06.Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }


        //04.Add a method in the GSM class for displaying all information about it. Try to override ToString().

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this.model != null)
            {
                result.AppendLine("Model: " + this.model);
            }
            else
            {
                result.AppendLine("Model: " + "NonInfo");
            }

            if (this.manufacturer != null)
            {
                result.AppendLine("Manufacturer: " + this.manufacturer);
            }
            else
            {
                result.AppendLine("Manufacturer: " + "NonInfo");
            }

            if (this.price != null)
            {
                result.AppendLine("Price: " + this.price);
            }
            else
            {
                result.AppendLine("Price: " + "NonInfo");
            }

            if (this.owner != null)
            {
                result.AppendLine("Owner: " + this.owner);
            }
            else
            {
                result.AppendLine("Owner: " + "NonInfo");
            }

            result.AppendLine();
            result.AppendLine("BATTERY INFORMATION");
            result.AppendLine();

            if (this.batteryCharacteristics.Type != null)
            {
                result.AppendLine("Battery type: " + this.batteryCharacteristics.Type);
            }
            else
            {
                result.AppendLine("Battery type: " + "NonInfo");
            }

            if (this.batteryCharacteristics.Model != null)
            {
                result.AppendLine("Battery model: " + this.batteryCharacteristics.Model);
            }
            else
            {
                result.AppendLine("Battery model: " + "NonInfo");
            }

            if (this.batteryCharacteristics.HoursIdle != null)
            {
                result.AppendLine("Hours idle: " + this.batteryCharacteristics.HoursIdle);
            }
            else
            {
                result.AppendLine("Hours idle: " + "NonInfo");
            }

            if (this.batteryCharacteristics.HoursTalk != null)
            {
                result.AppendLine("Hours talk: " + this.batteryCharacteristics.HoursTalk);
            }
            else
            {
                result.AppendLine("Hours talk: " + "NonInfo");
            }

            result.AppendLine();
            result.AppendLine("DISPLAY INFORMATION");
            result.AppendLine();

            if (this.displayCharacteristics.Size != null)
            {
                result.AppendLine("Display size: " + this.displayCharacteristics.Size);
            }
            else
            {
                result.AppendLine("Display size: " + "NonInfo");
            }

            if (this.displayCharacteristics.NumberOfColors != null)
            {
                result.AppendLine("Display colors: " + this.displayCharacteristics.NumberOfColors);
            }
            else
            {
                result.AppendLine("Display colors: " + "NonInfo");
            }

            return result.ToString();
        }


        //09.Add a property CallHistory in the GSM class to hold a list of the performed calls. Try to use the system class List<Call>.
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
        }

        //10.Add methods in the GSM class for adding and deleting calls from the calls history. Add a method to clear the call history.

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void DeleteCall(int callIndex)
        {
            if (callIndex >= 0 && callIndex < this.callHistory.Count)
            {
                this.callHistory.RemoveAt(callIndex);
            }
            else
            {
                throw new IndexOutOfRangeException("The call you want to delete is not valid!");
            }
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        //11.Add a method that calculates the total price of the calls in the call history. Assume the price per minute is fixed and is provided as a parameter.

        public decimal CalculateCallsPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0;

            foreach (Call call in this.callHistory)
            {
                decimal durationInMinutes = call.DurationInSeconds / 60;

                totalPrice += durationInMinutes * pricePerMinute;
            }

            return totalPrice;
        }
    }
}
