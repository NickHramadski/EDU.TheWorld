//site.js
(function () {
//    var ele = $("#username");
//    ele.text("Pappi Muchachos");
//
//    var main = $("#main");
//    main.on("mouseenter", function () {
//        main.style = "background-color: #888;";
//    });
//    main.on("mouseleave", function () {
//       main.style = "";
//    });
//    var menuItems = $("ul.menu li a");
//    menuItems.on("click", function () {
//       var me = $(this);
//        alert(me.text());
    //    });

    $sidebarAndWrapper = $("#sidebar, #wrapper");

    $("#sidebarToggle").on("click", function (e) {
        $sidebarAndWrapper.toggleClass("hide-sidebar");

        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).text("Show Sidebar!");
        } else {
            $(this).text("Hide Sidebar!");
        }
    });
})();



