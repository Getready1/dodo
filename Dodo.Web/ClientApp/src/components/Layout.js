import React, { Component } from 'react'
import { NavMenu } from './NavMenu/NavMenu'

import Media from 'react-media'

import { Responsive, Segment, SegmentGroup } from 'semantic-ui-react'

export class Layout extends Component {
  static displayName = Layout.name

  state = {
    device: null
  }

  getMobileContent() {
    return (
      <React.Fragment>
        <div style={{ display: 'flex', justifyContent: 'center', marginBottom: '20px' }}>
          <NavMenu device={'mobile'} />
        </div>
        <div className="eight wide column">{this.props.children}</div>
      </React.Fragment>
    )
  }

  getDesktopContent() {
    return (
      <div className="ui grid container">
        <div className="four wide column">
          <NavMenu device={'desktop'} />
        </div>
        <div className="twelve wide column">{this.props.children}</div>
      </div>
    )
  }

  render() {
    return (
      <div>
        <Media query="(max-width: 500px)" defaultMatches={this.state.device === 'mobile'} render={() => this.getMobileContent()} />

        <Media query="(min-width: 501px)" defaultMatches={this.state.device === 'desktop'} render={() => this.getDesktopContent()} />
      </div>
    )
  }
}
