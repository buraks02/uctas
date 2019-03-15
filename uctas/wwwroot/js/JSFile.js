$(document).ready(function(){
    let selectedStone;
    let selectedColor;
    let actionFinished;
    let stoneSelectedFromNode = false;

    $(".game-dot").click(function() {
        if(selectedStone && !stoneSelectedFromNode){
            //$(selectedStone).css('background-color:' , selectedColor);
            $(selectedStone).appendTo($(this));

            var nodeid = $(this).attr("asp-for-node-id");
            var playerName = $(selectedStone).attr("asp-player-name");
            var stoneId = $(selectedStone).attr("asp-stone-id");
            var playerInputOfNodeId = "#node-player-" + nodeid;
            var stoneInputOfNodeId = "#node-stone-" + nodeid;
            $(this).find(playerInputOfNodeId).val(playerName);
            $(this).find(stoneInputOfNodeId).val(stoneId);
            var playerStoneNodeId = playerName + stoneId;
            $(selectedStone).find(playerStoneNodeId).val(nodeid);
            $(selectedStone).css('background-color' , selectedColor);

            var oldNodeid = $(nodeThatStoneWillLeave).attr("asp-for-node-id");
            var playerInputOfOldNodeId = "#node-player-" + oldNodeid;
            var stoneInputOfoldNodeId = "#node-stone-" + oldNodeid;
            $(nodeThatStoneWillLeave).find(playerInputOfOldNodeId).val(null);
            $(nodeThatStoneWillLeave).find(stoneInputOfoldNodeId).val(null);

            selectedStone = null;
        }

        stoneSelectedFromNode = false;
    })

    $(".game-stone").click(function(event) {
        if(selectedStone != 'undefined' && selectedStone != null){
            $(selectedStone).css('background-color', selectedColor);
            selectedStone = null;
        }

        selectedStone = this;
        selectedColor = $(selectedStone).css('background-color');
        $(selectedStone).css('background-color' , 'maroon');

        var parentOfStone = $(selectedStone).parent().get(0);
        if($(parentOfStone).attr('class') == "game-dot"){
            if(parentOfStone != undefined){
                stoneSelectedFromNode = true;
                nodeThatStoneWillLeave = parentOfStone;
            }
        }
    })


});
