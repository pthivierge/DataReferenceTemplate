using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Asset.DataReference;
using OSIsoft.AF.UnitsOfMeasure;
using OSIsoft.AF.Time;


namespace DataReference
{
    [Guid("1D82729C-AA26-4657-A4C0-D9A335F2A972")] // HERE A NEW GUID NEEDS TO BE PROVIDED EACH TIME A NEW DATA REF IS CREATED
    [Description("DataRefTemplate;Data Reference Template")] // . The Description Attribute has the name and description that AF will use, separated by a semicolon.
    public class DataReferenceTemplate : AFDataReference
    {

        #region DataReferenceImplementation

        /// <summary>
        /// This method gets the value for multiple attributes based upon the data reference configuration within the specified context.
        /// </summary>
        /// <param name="attributes">The list of attributes to obtain the value of. The returned collection of AFValues will be specified in the same order as the list of attributes provided.</param>
        /// <param name="context">The AF SDK context to be used when getting the attributes' value. If the context is not null, then the value will be returned relative to the specified AF SDK object. The following AF SDK objects may be used as a context: AFCase, AFAnalysis, and AFModel. It is up to the data reference to determine how the context should be used when retrieving the attribute's value.</param>
        /// <param name="timeContext">The time context. If the context is null, then the most recent value is returned. If the context is an AFTime object, then the value at the specified time is returned. If the context is an AFTimeRange object, then the value for the specified time range is returned. For convenience, AF SDK will convert a time context of AFCase into a time range, time at case's end time, or null as appropriate.</param>
        /// <remarks>This method provides a mechanism to read multiple attribute values in one call, giving the data reference an opportunity to provide for faster performance than if retrieved by individual calls. Because this method is static, it must be overridden using the 'new' keyword in C#, or 'Shadows' in VB.NET. If this method is not provided in the Data Reference implementation, then the SDK will invoke the GetValue call for each attribute.</remarks>
        /// <see cref="https://techsupport.osisoft.com/Documentation/PI-AF-SDK/html/M_OSIsoft_AF_Asset_AFDataReference_GetValue.htm"/>
        /// <returns></returns>
        public static new AFValue GetValue(AFAttributeList attributes, Object context, Object timeContext)
        {
            return null;
        }

        /// <summary>
        /// This method gets the value based upon the data reference configuration within the specified context.
        /// <see cref="https://techsupport.osisoft.com/Documentation/PI-AF-SDK/html/M_OSIsoft_AF_Asset_AFDataReference_GetValue_1.htm"/>
        /// </summary>
        public override AFValue GetValue(object context, object timeContext, AFAttributeList inputAttributes, AFValues inputValues)
        {
            return new AFValue()
            {
                Timestamp = DateTime.Now,
                Value = 0
            };
        }

        /// <summary>
        /// This method gets a collection of AFValue objects for an attribute based upon the data reference configuration within the specified AFTimeRange context.
        /// <see cref="https://techsupport.osisoft.com/Documentation/PI-AF-SDK/html/M_OSIsoft_AF_Asset_AFDataReference_GetValues.htm"/>
        /// </summary>
        public override AFValues GetValues(object context, AFTimeRange timeRange, int numberOfValues, AFAttributeList inputAttributes,
            AFValues[] inputValues)
        {
            var afvalues = new AFValues();

            //insert logic to generate af values here 
            afvalues.Add(new AFValue()
            {
                Value = 0,
                Timestamp = new AFTime(timeRange.StartTime)
            });

            afvalues.Add(new AFValue()
            {
                Value = 1,
                Timestamp = new AFTime(timeRange.EndTime)
            });

            return afvalues;
        }

        /// <summary>
        /// <see cref="https://techsupport.osisoft.com/Documentation/PI-AF-SDK/html/T_OSIsoft_AF_Asset_AFDataReferenceContext.htm"/>
        /// </summary>
        public override AFDataReferenceContext SupportedContexts
        {
            get
            {
                return AFDataReferenceContext.Time |
                       AFDataReferenceContext.TimeRange |
                       AFDataReferenceContext.Analysis |
                       AFDataReferenceContext.Case |
                       AFDataReferenceContext.Model;

            }
        }

        /// <summary>
        /// <see cref="https://techsupport.osisoft.com/Documentation/PI-AF-SDK/html/T_OSIsoft_AF_Asset_AFDataReferenceMethod.htm"/>
        /// </summary>
        public override AFDataReferenceMethod SupportedMethods
        {
            get
            {
                return
                    AFDataReferenceMethod.GetValue |
                    AFDataReferenceMethod.GetValues;


            }
        }

        /// <summary>
        /// This property represents the current configuration of the Data Reference as a string suitable for displaying to an end-user and/or setting its configuration.
        ///<see cref="https://techsupport.osisoft.com/Documentation/PI-AF-SDK/html/P_OSIsoft_AF_Asset_AFDataReference_ConfigString.htm"/>
        /// <remarks>This method must be overridden and implemented by PlugIn implementer.</remarks>
        /// </summary>
        public override string ConfigString
        {
            get { return "unset"; }
            set { base.ConfigString = value; }
        }

        /// <summary>
        /// This method returns the Type of the editor that is used to configure this data reference.
        /// <remarks>The plugin may elect to not support a specific editor, in which case the Microsoft .NET Property Grid editor will be used. The plugin should use the appropriate .NET attributes on its properties to allow configuration in this manner.</remarks>
        /// </summary>
        public override Type EditorType
        {
            get { return typeof(DataReferenceConfigUI); }
        }

        #endregion DataReferenceImplementation
    }
}
