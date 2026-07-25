import { Directive, HostBinding, HostListener, Input } from '@angular/core';

@Directive({ selector: '[appHighlight]' })
export class HighlightDirective {
  @Input() appHighlight = 'yellow';
  @HostBinding('style.backgroundColor') backgroundColor = '';
  @HostListener('mouseenter') onMouseEnter(): void { this.backgroundColor = this.appHighlight; }
  @HostListener('mouseleave') onMouseLeave(): void { this.backgroundColor = ''; }
}
