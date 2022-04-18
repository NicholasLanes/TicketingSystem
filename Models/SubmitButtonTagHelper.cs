using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TicketingSystem.Models
{
    //SubmitButtonTagHelper applies to any non-standard <submit-button> element. Extends/Inherits TagHelper
    public class SubmitButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button"; // makes a button element
            output.TagMode = TagMode.StartTagAndEndTag; // with start and end tags

            // makes it a button with the same attributes as a submit button
            output.Attributes.SetAttribute("type", "submit");

            // appending style/bootstrap classes
            string newClasses = "btn btn-primary";
            string oldClasses = output.Attributes["class"]?.Value?.ToString(); // old classes is whatever value is included in the class attribute. May be null
            string classes = (string.IsNullOrEmpty(oldClasses)) ? // null checking old classes
                newClasses : $"{oldClasses} {newClasses}"; // new classes are the old classes with the new classes appended to the end
            output.Attributes.SetAttribute("class", classes); // set the class attribute to the new class properties
        }
    }
}
