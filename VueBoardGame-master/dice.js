// Define a new component called button-counter
Vue.component('button-counter', {
    data: function () {
      return {
        count: 0
      }
    },
    methods:{
        roleDice() {
            // console.log(Math.random()*6)
            let randomNumber = Math.random()*6;
            // console.log(randomNumber);
            // return Math.random()*6
            if (randomNumber <= 1) {
                // console.log(1)
                this.count = 1;
                return 1
            } else if (randomNumber > 1 && randomNumber <= 2) {
                // console.log(2)
                this.count = 2;
                return 2
            } else if (randomNumber > 2 && randomNumber <= 3) {
                this.count = 3;
                // console.log(3)
                return 3
            } else if (randomNumber > 3 && randomNumber <= 4) {
                // console.log(4)
                this.count = 4;
                return 4
            } else if (randomNumber > 4 && randomNumber <= 5) {
                // console.log(5)
                this.count = 5;
                return 5
            } else {
                // console.log(6)
                this.count = 6;
                return 6
            }
            
        }
    },
    template: '<button class="dice-button" v-if="count === 0" v-on:click="roleDice()">Click to Roll Die.</button> <div class="dice-div" v-else> You Rolled a {{ count }}. <button class="dice-button" v-on:click="roleDice()">Click to Roll Die.</button> </div>' 
  })

new Vue({ el: '#game' })