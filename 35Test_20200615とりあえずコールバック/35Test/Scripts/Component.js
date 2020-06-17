﻿Vue.config.devtools = true;
Vue.component('open-modal', {
    template: `
    <div id="overlay" v-if="show">
                <div class="overlay"></div>
                <div class="modal-container">
                    <div class="modal-body">
                        <p>{{msg}}</p>
                        <button v-on:click="callBack">はい</button>
                        <button v-on:click="clickNo">いいえ</button>
                    </div>
                </div>
            </div>
    `,
    props: {
        callBack: Function,
        show: Boolean,
        msg:String
    },

    methods: {
        clickYes: function () {
            this.callBack();
            //this.$emit('answerdConfirm', true)
            
        },
        clickNo: function () {
            this.$emit('click-no', false)
        }
    }
})