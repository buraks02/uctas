using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using uctas.Models;
using uctas.Models.ViewModels;

namespace uctas.Infrastructure.TagHelpers
{
    [HtmlTargetElement("nodediv")]
    public class NodeDivTagHelper : TagHelper
    {
        //[HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var node = (NodeViewModel)For.Model;
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "game-dot");
            output.Attributes.SetAttribute("id", $"game-dot-{node.NodeId}");
            output.Attributes.SetAttribute("player-name", node.PlayerName);
            output.Attributes.SetAttribute("stone-id", node.StoneId);
            output.Attributes.SetAttribute("node-id", node.NodeId);
            if (!string.IsNullOrEmpty(node.PlayerName))
            {
                var attributes = new TagHelperAttributeList(new[]
                        {
                            new TagHelperAttribute("player-name", node.PlayerName),
                            new TagHelperAttribute("stone-id", node.StoneId),
                            new TagHelperAttribute("stone-color", node.Color)
                            });
                var stonedivTagHelper = new StoneDivTagHelper
                {
                    PlayerName = node.PlayerName,
                    StoneColor = node.Color,
                    StoneId = node.StoneId
                };

                var stonedivOutput = new TagHelperOutput(
                tagName: "div",
                attributes: attributes,
                getChildContentAsync: (useCachedResult, encoder) =>
                     Task.Run<TagHelperContent>(() => new DefaultTagHelperContent())
                )
                {
                    TagMode = TagMode.StartTagAndEndTag
                };
                var stonedivContext = new TagHelperContext(
                    attributes,
                    new Dictionary<object, object>(),
                    Guid.NewGuid().ToString());

                stonedivTagHelper.Process(stonedivContext, stonedivOutput);

                //TagBuilder stoneDiv = new TagBuilder("stonediv");
                //stoneDiv.Attributes["player-name"] = PlayerName;
                //stoneDiv.Attributes["stone-id"] = StoneId;
                //stoneDiv.Attributes["stone-color"] = StoneColor;



                output.Content.SetHtmlContent(stonedivOutput);

                //output.Content.Append($"<stonediv stone-id={StoneId} class='game-stone' stone-color={StoneColor} player-name={PlayerName}></stonediv>");

            }
        }
    }
}
