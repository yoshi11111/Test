Vue.config.devtools = true;
Vue.component('open-modal', {
    template: `
    <div id="overlay" >
                <div class="overlay"></div>
                <div class="modal-container">
                    <div class="modal-body">
                        <p>送信するファイルを指定して、［送信］ボタンを押してください。</p>
        <p>
            <input id="ipt_file" type="file" />
        </p>
        <p>
        </p>
                        <button v-on:click="clickYes">はい</button>
                        <button v-on:click="clickNo">いいえ</button>
                    </div>
                </div>
            </div>
    `,
    props: {
        close: Function,
        back: Function,
        show: false
    },

    methods: {
        clickYes: function () {
            this.close();
            var upload_file = $('#ipt_file')[0];
            var oFile = upload_file.files[0];
            this.back(oFile);
        },
        clickNo: function () {
            this.close();
//            this.$emit('click-no', false);
        }
    }
});