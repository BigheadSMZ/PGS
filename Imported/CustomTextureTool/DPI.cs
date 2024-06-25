using System;
using System.Drawing;
using System.Windows.Forms;

// Imported from my C# version of Custom Texture Tool (which I never finished or released).

namespace PGS
{
    public static class DPI
    {
        // Get the current DPI stored in the registry.
        private static int Value;
        private static decimal Multiplier;
        private static int OffsetFix;

        // Initialize the static DPI values.
        public static void Init()
        {
            // Create a dummy form to get the DPI from.
            Form DPI_Form = new Form();

            // The graphics class can be used to get the DPI from the form.
            Graphics DPI_GFX = DPI_Form.CreateGraphics();

            // Grab the DPI from the dummy form and graphics class.
            DPI.Value = Convert.ToInt32(DPI_GFX.DpiX);
            DPI.Multiplier = (Value / 24m) * 0.25m;
            DPI.OffsetFix = Convert.ToInt32((Multiplier - 1) * 4);

            // Dispose the form now that it's no longer needed.
            DPI_Form.Dispose();
        }
        // A dynamic type allows the function to take any type of value. A switch is used to filter the type, and the result is cast into the type sent.
        public static dynamic Scale(dynamic Value, int Add = 0, int AddX = 0, int AddY = 0, bool Round = false)
        {
            // Get the type of the parameter passed.
            string ValueType = Value.GetType().ToString();

            // If the value fed was a string, convert it to an integer.
            if (ValueType == "System.String")
            {
                // Place the value into a strong type.
                string ValueString = Value;

                // Try to parse it as an integer.
                if (int.TryParse(ValueString, out _))
                {
                    // Hope it succeeds. This allows feeding strings as values to scale.
                    Value = Convert.ToInt32(Value);
                    ValueType = "System.Int32";
                }
            }
            // The type of variable will determine the calculation method.
            switch (ValueType)
            {
                case "System.Int16":
                    {
                        if (!Round) { Value = Math.Truncate(Convert.ToInt16(Value) * Multiplier); }
                        else { Value = Math.Round(Convert.ToInt16(Value) * Multiplier, MidpointRounding.AwayFromZero); }
                        return (Convert.ToInt16(Value) + Add + AddX + AddY);
                    }
                case "System.Int32":
                    {
                        if (!Round) { Value = Math.Truncate(Convert.ToInt32(Value) * Multiplier); }
                        else { Value = Math.Round(Convert.ToInt32(Value) * Multiplier, MidpointRounding.AwayFromZero); }
                        return (Convert.ToInt32(Value) + Add + AddX + AddY);
                    }
                case "System.Int64":
                    {
                        if (!Round) { Value = Math.Truncate(Convert.ToInt32(Value) * Multiplier); }
                        else { Value = Math.Round(Convert.ToInt32(Value) * Multiplier, MidpointRounding.AwayFromZero); }
                        return (Convert.ToInt32(Value) + Add + AddX + AddY);
                    }
                case "System.Single":
                    {
                        if (!Round) { Value = Math.Truncate(Convert.ToInt32(Value) * Multiplier); }
                        else { Value = Math.Round(Convert.ToInt32(Value) * Multiplier, MidpointRounding.AwayFromZero); }
                        return (Convert.ToInt32(Value) + Add + AddX + AddY);
                    }
                case "System.Double":
                    {
                        if (!Round) { Value = Convert.ToDouble(Value) * Multiplier; }
                        else { Value = Math.Round(Convert.ToDouble(Value) * Multiplier, MidpointRounding.AwayFromZero); }
                        return (Convert.ToDouble(Value) + Add + AddX + AddY);
                    }
                case "System.Decimal":
                    {
                        if (!Round) { Value = Convert.ToDecimal(Value) * Multiplier; }
                        else { Value = Math.Round(Convert.ToDecimal(Value) * Multiplier, MidpointRounding.AwayFromZero); }
                        return (Convert.ToDecimal(Value) + Add + AddX + AddY);
                    }
                case "System.Drawing.Size":
                    {
                        if (!Round) { Value = new Size((int)Math.Truncate(Value.Width * Multiplier), (int)Math.Truncate(Value.Height * Multiplier)); }
                        else { Value = new Size((int)Math.Round(Value.Width * Multiplier, MidpointRounding.AwayFromZero), (int)Math.Round(Value.Height * Multiplier, MidpointRounding.AwayFromZero)); }
                        return new Size((Value.Width + Add + AddX), (Value.Height + Add + AddY));
                    }
                case "System.Drawing.Point":
                    {
                        if (!Round) { Value = new Point((int)Math.Truncate(Convert.ToInt32(Value.X) * Multiplier), (int)Math.Truncate(Convert.ToInt32(Value.Y) * Multiplier)); }
                        else { Value = new Point((int)Math.Round(Convert.ToInt32(Value.X) * Multiplier, MidpointRounding.AwayFromZero), (int)Math.Round(Convert.ToInt32(Value.Y) * Multiplier, MidpointRounding.AwayFromZero)); }
                        return new Point((Value.X + Add + AddX), (Value.Y + Add + AddY));
                    }
            }
            // If all else fails, return the value that was fed.
            return Value;
        }
    }
}
