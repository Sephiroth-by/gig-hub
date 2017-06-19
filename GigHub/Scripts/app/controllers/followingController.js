var FollowingController = function (followingService) {
    var button;

    var init = function () {
        $(".js-toggle-follow").click(toggleFollowing);
    };

    var toggleFollowing = function(e){
        button = $(e.target);
        var artistId = button.attr("data-artist-id");

        if (button.hasClass("btn-default"))
            followingService.follow(artistId, done, fail);
        else
            followingService.unFollow(artistId, done, fail);
    };

    var done = function () {
        var text = button.text() == "Following?" ? "Following" : "Following?"
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var fail = function () {
        alert("Something failed!");
    };

    return {
        init: init
    }
}(FollowingService);