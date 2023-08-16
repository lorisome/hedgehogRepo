<template>
<div class="clickable-choice">
    <div class="ser-or-estar">
        <button class="ser" v-on:click="determineCorrectOrIncorrect($event)">Ser</button>
        <button class="estar" v-on:click="determineCorrectOrIncorrect($event)">Estar</button>
        <div class="hide correct-identifier">Correct</div>
    </div>
    <div class="past-or-present">
        <button class="past" v-on:click="determineCorrectOrIncorrect($event)">Past</button>
        <button class="present" v-on:click="determineCorrectOrIncorrect($event)">Present</button>
        <div class="correct-identifier hide">Correct</div>
    </div>
  </div>
</template>

<script>
export default {
props:['SerOrEstar', 'PastOrPresent', 'FinalVerbForm'],
methods:{
    //TODO: bind the elements instead of trying to manipulate the dom directly (especially since this isnn't working anyway)
    determineCorrectOrIncorrect(e){
        if((e.target.classList.contains(this.SerOrEstar) || e.target.classList.contains(this.PastOrPresent))){
            e.target.classList.toggle('correct')            
            e.target.parentNode.lastChild.classList.toggle('hide');
                e.target.parentNode.lastChild.innerText = 'Correct';                          
           
        }
        else {
            e.target.classList.toggle('incorrect')
            e.target.parentNode.lastChild.classList.toggle('hide');
            if(e.target.classList.contains('incorrect')){

                e.target.parentNode.lastChild.innerText = 'Incorrect';
            
            }
        }
    }
}
}
</script>

<style scoped>
div.clickable-choice{
    display: flex;
    flex-direction: column;
    justify-content:space-evenly;
    border: 2px solid #582a62;
    border-radius: 4px;
    margin: 5px;
    height: 130px;
    background-color: rgb(239, 239, 239);
}
.ser-or-estar,
.past-or-present{
    display:flex;
    justify-content:space-evenly;
    gap: 5px;
    align-items: center;
    padding-bottom: 15px;
}
button {
  padding: 10px 20px;
  width: 85px;
  border: 1px solid #ddd;
  color: #333;
  background-color:#fff;
  border-radius: 4px;
  font-size: 14px;
}

.correct{
    background-color:rgb(75, 211, 75)
}
.incorrect{
    background-color:rgb(238, 67, 67)
}
.hide{
    visibility:hidden;
}
.correct-identifier{
    color: darkgreen;

}
</style>