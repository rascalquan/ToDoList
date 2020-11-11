<template>
  <el-container>
    <el-header>
      <h1>大西西记事本</h1>
    </el-header>
    <el-main>
      <div class="main">
        <el-card class="box-card">
          <div id="newItem">
            <el-input
              v-model="newItem"
              placeholder="请输入待办事项"
              maxlength="100"
              @change="addItem"
              @keypress.enter="addItem"
            ></el-input>
          </div>

          <div v-for="item in todoItems" :key="item.id" class="todoItem">
            <el-card>
              <el-checkbox @change="changeState(item, true)"></el-checkbox>
              {{ item.content }}
            </el-card>
          </div>
          <el-collapse v-model="activeCollapse" v-show="showFinished">
            <el-collapse-item title="已完成" name="finishedCol">
              <div
                v-for="item in finishedItems"
                :key="item.id"
                class="finishedItem"
              >
                <el-card>
                  <el-checkbox
                    @change="changeState(item, false)"
                    checked
                  ></el-checkbox>
                  {{ item.content }}
                  <el-button
                    icon="el-icon-delete"
                    class="deleteFinished"
                    @click="removeFinish"
                  ></el-button>
                </el-card>
              </div>
            </el-collapse-item>
          </el-collapse>
        </el-card>
      </div>
    </el-main>
    <el-footer></el-footer>
  </el-container>
</template>

<script>
import { v4 as uuid } from "uuid";
export default {
  data() {
    return {
      newItem: "",
      todoItems: [],
      finishedItems: [],
      activeCollapse: ["finishedCol"],
    };
  },
  methods: {
    addItem: function () {
      this.todoItems.push({ id: uuid(), content: this.newItem });
      this.newItem = "";
    },
    changeState(item, finish) {
      if (finish) {
        this.finishedItems.push(item);
        let pos = this.todoItems.indexOf(item);
        this.todoItems.splice(pos, 1);
      } else {
        this.todoItems.push(item);
        let pos = this.finishedItems.indexOf(item);
        this.finishedItems.splice(pos, 1);
      }
    },
    removeFinish(item) {
      let pos = this.finishedItems.indexOf(item);
      this.finishedItems.splice(pos, 1);
    },
  },
  computed: {
    showFinished: function () {
      return this.finishedItems.length > 0;
    },
  },
};
</script>

<style scoped>
#app {
  text-align: center;
  /*background: url('images/bg.jpg') no-repeat center;*/
}
h1 {
  font-size: 34px;
  margin: 0;
  line-height: 48px;
  color: #c7bdbd;
}
.main {
  margin: auto;
  /* max-width: 400px; */
}
.box-card {
  max-width: 450px;
  min-height: 200px;
  margin: auto;
}
/* #newItem {
  margin-bottom: 15px;
} */
.todoItem,
.finishedItem {
  text-align: left;
  /* margin: 5px 0px; */
}
.finishedItem {
  text-decoration: line-through;
}
.deleteFinished {
  border-width: 0px;
  float: right;
}
el-footer {
  bottom: 0;
}
</style>
