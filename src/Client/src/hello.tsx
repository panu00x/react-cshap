import React from 'react';
import { Input, Button, message } from 'antd'
import { TApi } from './share/TApi'
import { getApiUrl } from './share/Configuration'

type State = {
    text: string,
};
type Props = {
    login: boolean
}
export class MyButton extends React.Component<Props, State> {
    constructor(props) {
        super(props);
        this.state = {
            text: null
        }
    }
    private tApi = new TApi(getApiUrl());

    private onText = e => {
        this.setState({ text: e.target.value })
    }

    private onSend = () => {
        let text = this.state.text
        this.tApi.getTest(text)
            .then(res => {
                message.success(res.data);
            })
            .catch(error => {
                console.log(error)
                message.error('กรุณาตรวจสอบอีกครั้ง')
            }
            );
    }
    render() {
        return <>
            <Button type="primary">Primary Button</Button>
            <Button>Default Button</Button>
            <Button type="dashed">Dashed Button</Button>
            <br />
            <Button type="text">Text Button</Button>
            <Button type="link">Link Button</Button>
            <Input placeholder="Text" onChange={this.onText} value={this.state.text} />
            <br />
            <br />
            <Button type="primary" onClick={this.onSend} block>
                Send
            </Button>
        </>
    }
}
