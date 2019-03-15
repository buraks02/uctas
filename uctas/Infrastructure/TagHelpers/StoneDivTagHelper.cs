using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace uctas.Infrastructure.TagHelpers
{
    [HtmlTargetElement("stonediv")]
    public class StoneDivTagHelper : TagHelper
    {
        public string PlayerName { get; set; }
        public int? StoneId { get; set; }
        public string StoneColor { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "game-stone");
            output.Attributes.SetAttribute("id", $"game-stone-{StoneId}");
            output.Attributes.SetAttribute("style", $"background-color:{StoneColor}");
            output.Attributes.SetAttribute("stone-id", StoneId);
            output.Attributes.SetAttribute("player-name", PlayerName);
        }
    
    }
}
