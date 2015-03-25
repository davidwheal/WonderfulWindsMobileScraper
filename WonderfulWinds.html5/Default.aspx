<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="Music Publisher" />
    <meta name="author" content="Wonderful Winds" />
    <title>Wonderful Winds Mobile Site</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../MyContent/WonderfulWinds.css" rel="stylesheet" />

</head>
<body ng-app="WonderfulWindsMobileApp">
    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">
                    <img src="../MyContent/WWLogo.jpg" style="height: 40px; width: 250px" />
                </a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav">
                    <li><a ui-sref="menu">Menu</a></li>
                    <li><a ui-sref="checkout">CheckOut</a></li>
                    <li><a ui-sref="about">About</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12 col-lg-12  main">
                <div ui-view></div>
            </div>
        </div>
    </div>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="../scripts/jquery-2.1.1.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/angular.min.js"></script>
    <script src="../scripts/angular-ui-router.min.js"></script>
    <script src="../scripts/angular-sanitize.min.js"></script>
    <script src="../scripts/angular.audio.js"></script>


    <%-- <script src="../scripts/AngularJSPDF/Angular-PDF.js"></script>--%>
    <script src="../MyScripts/Main.js"></script>
    <script src="../MyScripts/controllers/menucontroller.js"></script>
    <script src="../MyScripts/controllers/checkoutcontroller.js"></script>
    <script src="../MyScripts/controllers/menudetailscontroller.js"></script>
    <script src="../MyScripts/services/menuservice.js"></script>
    <script src="../MyScripts/services/basketservice.js"></script>

    <script src="../MyScripts/services/menudetailsservice.js"></script>
    <script src="../Scripts/ng-table/ng-table.min.js"></script>
    <script src="../Scripts/ng-table/ng-table.min.css"></script>
    <script>
        $(document).on('click', '.navbar-collapse.in', function (e)
        {
            if ($(e.target).is('a'))
            {
                $(this).collapse('hide');
            }
        });
    </script>
</body>
</html>
