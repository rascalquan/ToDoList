<template>
  <div id="app">
    <el-container>
      <el-header>
        <h1>大西西记事本</h1>
      </el-header>
      <el-main>
        <div class="main">
          <el-card class="box-card">
            <div id="newitem">
              <el-input
                v-model="newitem"
                placeholder="请输入待办事项"
                maxlength="100"
                @change="additem"
                @keypress.enter="additem"
              ></el-input>
            </div>

            <div v-for="item in todoitems" :key="item.id" class="todoitem">
              <el-checkbox @change="changestate(item, true)"></el-checkbox>
              {{ item.content }}
              <el-divider></el-divider>
            </div>
            <el-collapse v-model="activeCollapse" v-show="showFinished">
              <el-collapse-item title="已完成" name="finishedCol">
                <div
                  v-for="item in finisheditems"
                  :key="item.id"
                  class="finisheditem"
                >
                  <el-checkbox
                    @change="changestate(item, false)"
                    checked
                  ></el-checkbox>
                  {{ item.content }}
                  <el-button
                    icon="el-icon-delete"
                    class="deletefinish"
                    @click="removefinish"
                  ></el-button>
                  <el-divider></el-divider>
                </div>
              </el-collapse-item>
            </el-collapse>
          </el-card>
        </div>
      </el-main>
      <el-footer></el-footer>
    </el-container>
  </div>
</template>

<script>
import { v4 as uuidv4 } from "uuid";
export default {
  data() {
    return {
      newitem: "",
      todoitems: [],
      finisheditems: [],
      activeCollapse: ["finishedCol"],
    };
  },
  methods: {
    additem: function () {
      this.todoitems.push({ id: uuidv4(), content: this.newitem });
      this.newitem = "";
    },
    changestate: function (item, finish) {
      if (finish) {
        this.finisheditems.push(item);
        let pos = this.todoitems.indexOf(item);
        this.todoitems.splice(pos, 1);
      } else {
        this.todoitems.push(item);
        let pos = this.finisheditems.indexOf(item);
        this.finisheditems.splice(pos, 1);
      }
    },
    removefinish: function (item) {
      let pos = this.finisheditems.indexOf(item);
      this.finisheditems.splice(pos, 1);
    },
  },
  computed: {
    showFinished: function () {
      return this.finisheditems.length > 0;
    },
  },
};
</script>

<style scoped>
#app {
  /* font-family: Helvetica, sans-serif; */
  text-align: center;
  font-family: "Helvetica Neue", Helvetica, "PingFang SC", "Hiragino Sans GB",
    "Microsoft YaHei", "微软雅黑", Arial, sans-serif;
  /* background: url("./images/bg.jpg") no-repeat center; */
}
h1 {
  font-size: 34px;
  margin: 0;
  line-height: 48px;
  color: #555;
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
#newitem {
  margin-bottom: 15px;
}
.todoitem,
.finisheditem {
  text-align: left;
  /* margin: 5px 0px; */
}
.finisheditem {
  text-decoration: line-through;
}
.el-divider--horizontal {
  margin: 15px 0px;
}
.deletefinish {
  border-width: 0px;
  float: right;
}
</style>
