// Define a new component called button-counter
Vue.component('player-piece', {
    props:['name', 'color', 'y', 'x'],
    template: 
    `
        <span 
			v-bind:class="'circle'" 
			v-bind:style="{ 'position': 'absolute', 'left':x+'px', 'top':y+'px', 'width':radius+'px', 'height':radius+'px', 'background':color}"
			v-on:click="prompt();">
		</span>
    `,
    methods:{
        prompt:function(){
            alert('You clicked the '+this.color+' circle!');	
            this.color='none';
        }	
    },
    data: function () {
        return {
            orbs:[
                {id:1, radius:10, color:'green', x: 20, y: 500 },
                {id:2, radius:15, color:'purple', x: 150, y: 700},
                {id:3, radius:20, color:'black', x: 90, y: 150},
                {id:4, radius:25, color:'blue', x: 200, y: 270},
                {id:5, radius:30, color:'orange', x: 440, y: 10},
                {id:6, radius:35, color:'yellow', x: 890, y: 300},
                {id:7, radius:45, color:'red', x: 560, y: 800}
            ]
        }
      },
  })

new Vue({ el: '#game' })