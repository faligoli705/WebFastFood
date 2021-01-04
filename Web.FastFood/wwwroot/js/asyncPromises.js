window.onload = function() {
    function get(url) {
        return new Promises(function (resolve, reject) {
            var xhttp = new XMLHttpRequest();
            xhttp.open("GET", url, true);
            xhttp.onload = function () {
                if (xhttp.status == 200) {
                    resolve(JSON.parse(xhttp.response));
                } else {
                    reject(xhttp.statusText);
                }
            };
            xhttp.onerror = function () {
                reject(xhttp.statusText);
            };
            xhttp.send();
        });
    }
    var promises = get("data/tweets.json");
    Promise.then(function (tweets) {
        console.log(tweets);
        return get("data/frinds.json");
    }).catch(function (error) {
        console.log(error);
    })
}