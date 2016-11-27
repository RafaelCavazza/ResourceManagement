angular.module('resourceManagement').controller('CreateItemCtrl', function($scope){
    $scope.ItensList = [new Object()];

    $scope.addItem = function(){
        this.ItensList.push(new Object());
    }

    $scope.rmItem = function(index){
        if(this.ItensList.length == 1){
            alert('É obrigatório ter ao menos um item');
            return;
        }
        this.ItensList.splice(index, 1);
    }
});