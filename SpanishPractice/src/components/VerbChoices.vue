<template>
  <div class="verb-choices">
    <div class="container" v-for="verb in this.currentChoices" v-bind:key='verb.index' >
    <button :class="['verb',{ correct: verb.showCorrect, incorrect:verb.showIncorrect }]" v-on:click="verb.showCorrect=VerbAnswer===verb.word;verb.showIncorrect=VerbAnswer!=verb.word">{{verb.word}}</button>
    </div>
  </div>
</template>

<script>
export default {
props: ['VerbAnswer'],
data(){
  return{
    allArrays:[
    [{word:'soy',showCorrect:false, showIncorrect:false}, {word:'eres',showCorrect:false, showIncorrect:false}, {word:'es',showCorrect:false, showIncorrect:false}, {word:'son',showCorrect:false, showIncorrect:false}, {word:'somos',showCorrect:false, showIncorrect:false}],
    [{word:'era',showCorrect:false, showIncorrect:false}, {word:'eras',showCorrect:false, showIncorrect:false}, {word:'eran',showCorrect:false, showIncorrect:false}, {word:'eramos',showCorrect:false, showIncorrect:false}],
    [{word:'estoy',showCorrect:false, showIncorrect:false}, {word:'estás',showCorrect:false, showIncorrect:false}, {word:'está',showCorrect:false, showIncorrect:false}, {word:'están',showCorrect:false, showIncorrect:false}, {word:'estamos',showCorrect:false, showIncorrect:false}],
    [{word:'estaba',showCorrect:false, showIncorrect:false}, {word:'estabas',showCorrect:false, showIncorrect:false}, {word:'estaban',showCorrect:false, showIncorrect:false}, {word:'estabamos',showCorrect:false, showIncorrect:false}]
    ],
    currentChoicesIndex: 0
  }
},
mounted(){
    for(let i = 0; i < this.allArrays.length; i++){
     for(let j = 0; j<this.allArrays[i].length;j++){
      if(this.allArrays[i][j].word == this.VerbAnswer){
      this.currentChoicesIndex= i;
      return;
      }
    }
  }
},
computed: {
  currentChoices(){
    return this.allArrays[this.currentChoicesIndex]
}
}
}
</script>

<style scoped>
.verb-choices{
  display:flex;
  justify-content: center;
  gap: 5px;
}
.correct{
    background-color:rgb(75, 211, 75)
}
.incorrect{
    background-color:rgb(238, 67, 67)
}
</style>