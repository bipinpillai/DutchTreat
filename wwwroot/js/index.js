$(document).ready(function () {
    console.log("testing 123");

    var theForm = $("#theForm");
    theForm.hide();

    var buyButton = $("#buyButton");
    buyButton.on("click", function () { console.log("Buy this item"); });

    var productProps = $(".product-props li");
    productProps.on("click", function () { console.log("You clicked on " + $(this).text()); });

    var $loginToggle = $("#loginToggle");
    var $popup = $(".pop-upForm");

    $loginToggle.on("click", function () { $popup.toggle(500); })


    //var theForm = document.getElementById("theForm");
    //theForm.hidden = true;

    //var buyButton = document.getElementById("buyButton");
    //buyButton.addEventListener("click", function () { console.log("Buy this item"); })
});