

myApp.controller('MenuDetailsController', ['$scope', '$location', '$sce', 'menuDetailsService', 'ngAudio','basketService',
    function ($scope, $location, $sce, menuDetailsService, ngAudio, basketService)
    {
        $scope.quantity = 1;
        $scope.error = "";
        $scope.displayerror = false;
        $scope.menudetails = {};
        $scope.items = {};
        $scope.id = $location.path().split('/')[2];
        //$scope.audio = "";
        //$scope.playing = false;
        $scope.player;

        getMenuDetails($scope.id);

        // Get rid of css calls so we can use the one here
        // Get rid of *Listen* bits of html
        // Get rid of the text explanation for *Listen* which is no longer applicable
        // for mobile.
        stripCss = function (html)
        {
            var cssImport = '@import url(http://www.wonderfulwinds.com/css/custom.css);';
            var myregexp = new RegExp(escapeRegExp(cssImport), 'gim');
            var fixup = html.replace(myregexp, '');
            var mp3Import = /(\*LISTEN\*)/gim;
          
            fixup = fixup.replace(mp3Import, '');
            var blurbImport = /(You can view.+?reproductions)/gim;
            fixup = fixup.replace(blurbImport, '');
           
            return fixup;
        }

        function escapeRegExp(string)
        {
            return string.replace(/([.*+?^${}()|\[\]\/\\])/g, "\\$1");
        }

        // Get the body to display and strip out external css calls
        // so I can use my own css
        $scope.getHtmlBody = function (id)
        {
            var fixed = stripCss($scope.items[id].BodyHtml);
            var urls = $scope.items[id].Urls;

            return $sce.trustAsHtml(fixed);
        }

        $scope.Buy = function (item,quantity)
        {
            basketService.addToBasket(item,quantity);
          
          
        }

        // Play the soundclip, only one at a time
        $scope.Play = function (item)
        {
            if (item.playing == true)
            {
                $scope.Stop(item);
            }
            $scope.player = item.SoundUrl.Audio;
            item.playing = true;
            $scope.player.play();
            $scope.playing = true;
        }

        // Stop a sound clip if one playing
        $scope.Stop = function (item)
        {
            if (item.playing == true)
            {
                $scope.player.stop();
                item.playing = false;
            }
        }

        function getMenuDetails(id)
        {
            // The Service returns a promise.
            menuDetailsService.getMenuDetails(id).then(
                function (data)
                {
                    $scope.menudetails = $sce.trustAsHtml(stripCss(data.Item.SynopsisHtml));
                    $scope.items = data.Item.Items;
                    for (var i = 0; i < $scope.items.length; i++)
                    {
                        if ($scope.items[i].SoundUrl)
                        {
                            $scope.items[i].SoundUrl.Audio = ngAudio.load($scope.items[i].SoundUrl.Url);

                        }
                        
                    }

                },
                function (reason)
                {
                    $scope.error = reason;
                    $scope.displayerror = true;
                    console.log("Menu details failed load", reason);
                }
                );


        }



    }

]
);
