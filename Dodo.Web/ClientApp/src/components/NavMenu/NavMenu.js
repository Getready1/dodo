import React, { Component } from 'react'
import { Input, Icon, Menu } from 'semantic-ui-react'
import { Link } from 'react-router-dom'
import Media from 'react-media'

export class NavMenu extends Component {
  constructor(props) {
    super(props)
    this.state = {
      activeItem: 'todo'
    }
  }

  menuItems = [
    {
      link: '/',
      name: 'todo',
      icon: {
        content: 'crosshairs',
        color: 'red'
      },
      text: 'To Do'
    },
    {
      link: '/towatch',
      name: 'towatch',
      icon: {
        content: 'eye',
        color: 'blue'
      },
      text: 'To Watch'
    },
    {
      link: '/toread',
      name: 'toread',
      icon: {
        content: 'book',
        color: 'green'
      },
      text: 'To Read'
    },
    {
      link: '/tobuy',
      name: 'tobuy',
      icon: {
        content: 'dollar sign',
        color: 'yellow'
      },
      text: 'To Buy'
    }
  ]

  onMenuClick = name => {
    this.setState({
      activeItem: name
    })
  }

  toggleActive = name => (this.state.activeItem === name ? 'active' : '')

  render() {
    return (
      <Menu icon="labeled" compact {...(this.props.device === 'mobile' ? {} : { vertical: true })}>
        {this.menuItems.map(mi => (
          <Link to={mi.link} key={mi.name}>
            <span className={`item ${this.toggleActive(mi.name)}`} onClick={() => this.onMenuClick(mi.name)}>
              <Icon name={mi.icon.content} size="large" color={mi.icon.color} />
              {this.props.device === 'desktop' && mi.text}
            </span>
          </Link>
        ))}
      </Menu>
    )
  }
}
