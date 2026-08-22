import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-settings-layout',
  standalone: true,
  imports: [CommonModule, RouterModule, RouterLink, RouterLinkActive],
  templateUrl: './settings-layout.component.html',
  styleUrl: './settings-layout.component.scss',
  styles: [`
    .nav-link { padding-top: 15px; padding-bottom: 15px; }
    .dropdown:hover .dropdown-menu { display: block; margin-top: 0; }
    .cursor-pointer { cursor: pointer; }
  `]
})
export class SettingsLayoutComponent {
}
