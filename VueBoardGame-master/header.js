// Define a new component called button-counter
Vue.component('game-header', {
    data: function () {
      return {
        title: `Adam's Vue Monopoly Game`,
      }
    },
    template: 
        `
         <header>
            <h1>Adam's Vue Monopoly Game</h1>
         </header>
        `
  })

new Vue({ el: '#game' })