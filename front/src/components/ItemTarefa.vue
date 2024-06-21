<template>

<div class="container">

<div class="bloco">
    
   <h2> {{titulo}} </h2>
    
       {{objetivo}}
    </div>


 <div class="blocoBotoes">
      <div class="botoes-container">
        <div class="botao">
          <i style="color:#fff" @click="editar" class="fa-solid fa-pencil"></i>
        </div>
        <div class="botao">
          <i style="color:#fff" @click="deletar" class="fa-solid fa-trash"></i>
        </div>
        <div class="botao">
          <i style="color:#0f0" @click="marcarConcluida" class="fa-solid fa-check"></i>
        </div>
      </div>
</div>
</div>

</template>

<script>

import axios from "axios"
import {urlBackend} from '../utils/configuracao.js'


export default {
 
 props: ["titulo", "objetivo", "id"],

  emits : ["deletar"],

methods:  {
    deletar() {
        axios.delete(`${urlBackend}/tarefas` + "/" + this.id).then( () => {
                    this.$emit('atualizar-lista-tarefas')

        })
    },
      marcarConcluida() {
        axios.put(`${urlBackend}/tarefas/concluidas` + "/" + this.id).then( () => {
                    this.$emit('atualizar-lista-tarefas')

        })

    }
,
      editar() {

         

            this.$emit('exibir-modal-editar', {id: this.id})

       

    }


    }
}
</script>

<style scoped>

.container {
    display: flex;
    flex-direction: row;
    background-color: #404040;
    margin: 10px;

}

.bloco {
    flex: 5;
    padding: 10px;
}

.blocoBotoes {
    flex: 1
}

.botoes-container {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  height: 100%;
}

.botao {
  display: flex;
  align-items: center;
  justify-content: center;
  flex: 1;
}


button {
    background-color:#f0f
}

h2 {
  color: #0ECA76
}

</style>