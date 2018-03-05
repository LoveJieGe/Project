Ext.define('SSJT.view.person.WizardController', {
    extend: 'SSJT.view.widgets.WizardController',
    alias: 'controller.personwizard',
    onUsernameChange: function(field, value) {
        // If the username field changed and is different from the last generated value, then
        // the user has manually entered a value that we don't want to overwrite, so let's
        // cancel the current generating process (if any) and reset the generated value.
        if (value !== this._generatedUsername) {
            this._generatedUsername = false;
        }
    },

    doPasswordMatch: function(value) {
        return this.lookup('password').getValue() !== value?
            '密码不匹配' :
            true;
    }
});
