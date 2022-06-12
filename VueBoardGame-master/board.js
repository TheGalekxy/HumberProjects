// Define a new component called button-counter
Vue.component('board-grid', {
    data: function () {
        let createdCells = new Array(9);
        for (let i = 0; i < 9; i++) {
            createdCells[i] = new Array(9);
        }
      return {
        cells: createdCells,
      }
    },
    template: `
    <table>
    <thead>
      <tr>
      </tr>
    </thead>
    <tbody>
        <tr>
            <td v-for="entry in cells" class="boardgame-tile">
            </td> 
        </tr>
        <tr>
            <td class="boardgame-tile">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="boardgame-tile">
            </td>
        </tr>
        <tr>
            <td class="boardgame-tile">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="boardgame-tile">
            </td>
        </tr>
        <tr>
            <td class="boardgame-tile">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="boardgame-tile">
            </td>
        </tr>
        <tr>
            <td class="boardgame-tile">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="boardgame-tile">
            </td>
        </tr>
        <tr>
            <td class="boardgame-tile">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="boardgame-tile">
            </td>
        </tr>
        <tr>
            <td class="boardgame-tile">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="boardgame-tile">
            </td>
        </tr>
        <tr>
            <td class="boardgame-tile">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="blank">
            </td>
            <td class="boardgame-tile">
            </td>
        </tr>
        <tr>
            <td v-for="entry in cells" class="boardgame-tile">
            </td> 
        </tr>
    </tbody>
  </table>
  `
  })

new Vue({ el: '#game' })