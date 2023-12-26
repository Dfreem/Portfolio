using System.Text.RegularExpressions;


namespace Portfolio.Data;

public sealed partial class CssTransformService
{

    #region fields
    private bool _perspectiveEnabled;
    private string _perspective = default!;
    private string _savedPerspective = default!;
    private string _skewX = default!;
    private string _translateX = default!;
    private string _translateY = default!;
    private string _translateZ = default!;
    private string _rotateX = default!;
    private string _rotateY = default!;
    private string _rotateZ = default!;
    private string _matrix3d = default!;

    #endregion

    /// <summary>
    /// An abstraction of the css tranform functions <br />
    /// IE:
    ///     <br /> - perspective 
    ///     <br /> - skewX
    ///     <br /> - translateX
    ///     <br /> - translateY
    ///     <br /> - translateZ
    ///     <br /> - rotateX
    ///     <br /> - rotateY
    ///     <br /> - rotateZ
    ///     <br /> - matrix3d 
    ///     <br />
    ///     <br />
    /// Matrix3d is the only parameter that cannot be set directly. <br /> 
    /// In order to set the value of one the transform functions, <br /> 
    /// set the parameter to a string version of the numerical value you wish to set it to, you cannot specify units. <br /> 
    /// Ex: the following statement set's the TranslateX property of an instance named `Tool` to 26px. <code>Tool.TranslateX = "26"</code>
    /// </summary>
    public CssTransformService()
    {
        SetTransform("0");
    }

    public string Matrix3d
    {
        get => _matrix3d ?? "";
        set => _matrix3d = value;
    }

    #region Properties

    public bool PerspectiveEnabled
    {
        get => _perspectiveEnabled;
        set
        {
            _perspectiveEnabled = value;
            if (_perspectiveEnabled)
            {
                _perspective = _savedPerspective;
            }
            else
            {
                _savedPerspective = _perspective;
                _perspective = "perspective(none)";
            }
        }
    }

    public string SkewX
    {
        get => _skewX ?? "";
        set => _skewX = SkewXPattern().IsMatch(value) ? value : $"skewX({value}deg)";
    }

    public string TranslateX
    {
        get => _translateX ?? "";
        set => _translateX = TranslateXPattern().IsMatch(value) ? value : $"translateX({value}px)";
    }
    public string TranslateY
    {
        get => _translateY ?? "";
        set => _translateY = TranslateYPattern().IsMatch(value) ? value : $"translateY({value}px)";
    }
    public string TranslateZ
    {
        get => _translateZ ?? "";
        set => _translateZ = TranslateZPattern().IsMatch(value) ? value : $"translateZ({value}px)";
    }
    public string RotateX
    {
        get => _rotateX ?? "";
        set => _rotateX = RotateXPattern().IsMatch(value) ? value : $"rotateX({value}deg)";
    }
    public string RotateY
    {
        get => _rotateY ?? "";
        set => _rotateY = RotateYPattern().IsMatch(value) ? value : $"rotateY({value}deg)";
    }
    public string RotateZ
    {
        get => _rotateZ ?? "";
        set => _rotateZ = RotateZPattern().IsMatch(value) ? value : $"rotateZ({value}deg)";
    }

    /// <summary>
    /// for disabling this value, set property to "0" or "none".
    /// </summary>
    public string Perspective
    {
        get
        {
            if (PerspectiveEnabled)
            {
                return _perspective ?? "";
            }
            return "";
        }
        set
        {
            if (!PerspectiveEnabled)
            {
                return;
            }
            if (PerspectivePattern().IsMatch(value))
            {
                _perspective = value;
            }
            else
            {
                _perspective = value.Contains("px") || value.Contains("none") ? $"perspective({value})" : $"perspective({value}px)";
            }
        }
    }


    public string TransformStyle { get; set; } = "preserve-3d";

    /// <summary>
    /// Set the transform string to a space seperate list of css transform functions as if setting the css transform attribute on an element.<br />
    /// To set an individual property to a value with no units instead of a css function, set the corresponding property on this <see cref="CssTransformService"/> instance.<br />
    /// In order to set all the properties to their effective zero state, this property may be set to either "0" or "(0)"
    /// </summary>
    public string TransformString
    {
        // perspective must be listed first if present
        get => (_perspective + " " +
                _skewX + " " +
                _translateX + " " +
                _translateY + " " +
                _translateZ + " " +
                _rotateX + " " +
                _rotateY + " " +
                _rotateZ + " " +
                _matrix3d).Trim();
        set
        {
            if (value is not null)
            {
                SetTransform(value);
            }
        }
    }

    #endregion

    internal void SetTransform(string value)
    {
        // we take care of matrix before splitting at ' ' because this would break the matrix
        if (Matrix3dPattern().IsMatch(value))
        {
            this.Matrix3d = Matrix3dPattern().Match(value).Value.Trim();

            // remove the matrix that has been used, then set other transforms as normal
            value = Matrix3dPattern().Replace(value, "");
        }
        string[] allTransforms = value.Split(' ');
        Array.ForEach(allTransforms, t =>
        {
            switch (t)
            {
                case var skew when SkewXPattern().IsMatch(t):
                    skew = SkewXPattern().Match(skew).Groups[0].Value;
                    _skewX = skew;
                    break;
                case var transX when TranslateXPattern().IsMatch(t):
                    transX = TranslateXPattern().Match(transX).Groups[0].Value;
                    _translateX = transX;
                    break;

                case var transY when TranslateYPattern().IsMatch(t):
                    transY = TranslateYPattern().Match(transY).Groups[0].Value;
                    _translateY = transY;
                    break;
                case var transZ when TranslateZPattern().IsMatch(t):
                    transZ = TranslateZPattern().Match(transZ).Groups[0].Value;
                    _translateZ = transZ;
                    break;
                case var rotateY when RotateYPattern().IsMatch(t):
                    rotateY = RotateYPattern().Match(rotateY).Groups[0].Value;
                    _rotateY = rotateY;
                    break;
                case var rotateX when RotateXPattern().IsMatch(t):
                    rotateX = RotateXPattern().Match(rotateX).Groups[0].Value;
                    _rotateX = rotateX;
                    break;
                case var rotateZ when RotateZPattern().IsMatch(t):
                    rotateZ = RotateZPattern().Match(rotateZ).Groups[0].Value;
                    _rotateZ = rotateZ;
                    break;
                case var perspective when PerspectiveEnabled && PerspectivePattern().IsMatch(t):
                    perspective = PerspectivePattern().Match(perspective).Groups[0].Value;
                    _perspective = perspective;
                    break;

                // dont reset matrix, it's used for storing any pre-existing transforms
                case var _ when t == "0" || t == "(0)":
                    if (PerspectiveEnabled)
                    {

                        _perspective = "perspective(none)";
                    }
                    _skewX = "skewX(0deg)";
                    _translateX = "translateX(0px)";
                    _translateY = "translateY(0px)";
                    _translateZ = "translateZ(0px)";
                    _rotateX = "rotateX(0deg)";
                    _rotateY = "rotateY(0deg)";
                    _rotateZ = "rotateZ(0deg)";


                    break;
                default:
                    break;
            }
        });
    }

    #region Regex

    [GeneratedRegex("skewX\\((-?\\d*).*\\)")]
    private static partial Regex SkewXPattern();

    [GeneratedRegex("translateX\\((-?\\d*).*\\)")]
    private static partial Regex TranslateXPattern();

    [GeneratedRegex("translateY\\((-?\\d*).*\\)")]
    private static partial Regex TranslateYPattern();

    [GeneratedRegex("translateZ\\((-?\\d*).*\\)")]
    private static partial Regex TranslateZPattern();

    [GeneratedRegex("rotateY\\((-?\\d*).*\\)")]
    private static partial Regex RotateYPattern();

    [GeneratedRegex("rotateX\\((-?\\d*).*\\)")]
    private static partial Regex RotateXPattern();

    [GeneratedRegex("rotateZ\\((-?\\d*).*\\)")]
    private static partial Regex RotateZPattern();

    [GeneratedRegex("perspective\\((-?\\d*).*\\)")]
    private static partial Regex PerspectivePattern();

    [GeneratedRegex("matrix3?d?\\([-\\d*\\.?\\d*,\\s]*\\)")]
    private static partial Regex Matrix3dPattern();

    public override string ToString()
    {
        return TransformString;
    }
    #endregion
}
