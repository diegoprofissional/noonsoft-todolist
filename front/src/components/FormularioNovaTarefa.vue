<template>
<form @submit.prevent="">
<div class="container">
    <div class="bloco">
<div> <label>titulo:</label> </div>
<input v-model="titulo">
 </div>

     <div class="bloco">

<div><label>objetivo:</label></div>
<input v-model="objetivo">
     </div>

      <div class="bloco">

<div>
<button @click="adicionarTarefa">adicionar</button>
</div>

        </div>

</div>


</form>
</template>


<script>

import axios from "axios"
import {urlBackend} from '../utils/configuracao.js'


export default {

    data() {
        return {
            titulo: '',
            objetivo : ''
        }
    },

    emits: ['atualizar-lista-tarefas']
,
methods: {
    adicionarTarefa(){

       let data = {
        titulo: this.titulo,
        objetivo: this.objetivo,
       }

        axios.post(`${urlBackend}/tarefas`, data).then(() => {
    this.$emit('atualizar-lista-tarefas');
  }).catch(() => {
    alert("Por favor preencha todos os campos")
  })

    }
    
}
}
</script>

<style scoped>

.container {
    display: flex;
    flex-direction: row;
    margin-bottom: 10px;
}

.bloco {
    flex: 1
}

button {
    background-color:#00E67D;
    padding:10px;
    border: 0px;
}

label {
 color:#fff;
 font-weight: bold;
}

</style>