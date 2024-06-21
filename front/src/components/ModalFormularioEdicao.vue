<template>


    <div v-if="visivel" class="modal fade show" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" style="display: block;">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Editar Tarefa</h5>
            <button type="button" @click="visivel = false" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            
            <div>
           <div> <label>titulo:</label> </div>
            <input v-model="titulo">
            </div>

          <div>
           <div>  <label>objetivo:</label></div>
            <input v-model="objetivo">
          </div>
          </div>
          <div class="modal-footer">
            <button @click="salvar" type="button" class="btn btn-primary">Salvar</button>
          </div>
        </div>
      </div>
    </div>


 

</template>

<script>

import {urlBackend} from '../utils/configuracao.js'
 
import axios from 'axios'

export default {

  props: {
    visible: Boolean,
    id: Number

  },
  data(){
    return {
      visivel: this.visible,
      titulo: '',
      objetivo: ''
    }
  },
  methods: {
    openClose(){
      this.openClose = !this.openClose;
    },
    salvar(){

      this.visivel = false

       const dados = {
          titulo: this.titulo,
          objetivo: this.objetivo
       }

      axios.put(`${urlBackend}/tarefas` + "/" + this.id, dados).then( () => {
                    this.$emit('atualizar-lista-tarefas')

        })

    }
  },
  watch: {
    visible: function(newVal){
      this.openClose = newVal
    }
  },
  mounted(){
       axios.get(`${urlBackend}/tarefas/` + this.id).then(resultado => {
            this.titulo = resultado.data.titulo;
            this.objetivo = resultado.data.objetivo;
             console.log("resultado")
            console.log(resultado)

        }).catch(e => {
          console.log(e)
        })
  }

}
</script>
