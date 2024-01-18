(function () {
    NNoAuthPage("about", "AboutPage", function (app, vm) {
        self.GoToHomePage = function () {
            app.GoToPage("/home");
        }
    });
})();
