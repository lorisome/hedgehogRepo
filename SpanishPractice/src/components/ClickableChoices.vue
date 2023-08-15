<template>
<div class="clickable-choice">
    <div class="ser-or-estar">
        <button class="ser" v-on:click="determineCorrectOrIncorrect($event)">Ser</button>
        <button class="estar" v-on:click="determineCorrectOrIncorrect($event)">Estar</button>
        <span class="hide"></span>
    </div>
    <div class="past-or-present">
        <button class="past" v-on:click="determineCorrectOrIncorrect($event)">Past</button>
        <button class="present" v-on:click="determineCorrectOrIncorrect($event)">Present</button>
    </div>
  </div>
</template>

<script>
export default {
props:['SerOrEstar', 'PastOrPresent', 'FinalVerbForm'],
methods:{
    determineCorrectOrIncorrect(e){
        if(e.target.classList.contains(this.SerOrEstar) || e.target.classList.contains(this.PastOrPresent)){
            e.target.classList.toggle('correct')
            // e.target.parentNode.lastChild.classList.toggle('hide');
            // e.target.parentNode.lastChild.innerText='Correct';
        }
        else{
            e.target.classList.toggle('incorrect')
            // e.target.parentNode.lastChild.classList.toggle('hide')
            // e.target.parentNode.lastChild.innerText='Incorrect'
        }
    }
}
}
</script>

<style>
div.clickable-choice{
    display: flex;
    flex-direction: column;
}
.ser-or-estar{
    display:flex;
    justify-content:center;
    gap: 5px;
}
button {
  padding: 10px 20px;
  border: 1px solid #ddd;
  margin-bottom: 5px;
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
</style>