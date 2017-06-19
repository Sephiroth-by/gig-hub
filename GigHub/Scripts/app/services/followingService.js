var FollowingService = function () {
    var follow = function (artistId, done, fail) {
        $.post("/api/followings", { artistId: artistId })
           .done(done)
           .fail(fail);
    };

    var unFollow = function (artistId, done, fail) {
        $.ajax({
            url: "/api/followings/" + artistId,
            method: "DELETE"
        })
        .done(done)
        .fail(fail);
    }

    return {
        follow: follow,
        unFollow: unFollow
    }
}();