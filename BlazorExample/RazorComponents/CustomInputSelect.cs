using Microsoft.AspNetCore.Components.Forms;

namespace RazorComponents
{
    /*
     *  InputSelect does not support the type System.Int32 see source code below
     *  https://github.com/dotnet/aspnetcore/blob/58c13c312eabfb00fdb56c7e0f69813359d2fa9a/src/Components/Web/src/Forms/InputSelect.cs
     */
    public class CustomInputSelect<TValue> : InputSelect<TValue>
    {
        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out TValue result,
            out string validationErrorMessage)
        {
            if (typeof(TValue) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (TValue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage =
                        $"The selected value {value} is not a valid number.";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result,
                    out validationErrorMessage);
            }
        }
    }
}
