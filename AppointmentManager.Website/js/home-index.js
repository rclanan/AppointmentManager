// home-index.js
var module = angular.module("homeIndex", []);

module.config(function($routeProvider) {
    $routeProvider.when("/", {
        controller: "homeIndexController",
        templateUrl: "/templates/staffMembersView.html"
    });
    $routeProvider.otherwise({ redirectTo: "/" });
});

function homeIndexController($scope, $http) {
    $scope.staffMembers = [];
    $scope.appointments = [];
    $scope.isBusy = true;

    $http.get("/api/v1/staffmembers")
        .then(function(result) {
            // Successful
            angular.copy(result.data, $scope.staffMembers);
        },
            function() {
                // Error
                alert("could not load staff members");
            }).then(function() {
                $scope.isBusy = false;
            });

    $scope.$watch(
        "selectedStaffMember",
        function(newValue, oldValue) {

            // Ignore initial setup.
            if (newValue === oldValue) {
                return;
            }

            //console.log("$watch: selectedStaffMember changed: " + $scope.selectedStaffMember);

            // Ignore if form already mirrors new value.
            if ($scope.selectedStaffMember === newValue) {
                $scope.isBusy = true;

                $http.get("/api/v1/staffmembers/" + newValue + "/appointments/2012-01-03")
                    .then(function (result) {
                        // Successful
                        
                        angular.copy(result.data, $scope.appointments);
                    },
                        function () {
                            // Error
                            alert("could not load staff appointments");
                        }).then(function () {
                            $scope.isBusy = false;
                        });
                return;
            }
        }
    );
}