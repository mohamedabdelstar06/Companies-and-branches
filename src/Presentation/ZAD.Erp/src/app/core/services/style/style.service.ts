import { DOCUMENT } from '@angular/common';
import { Inject, Injectable, Renderer2, RendererFactory2 } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StyleService {
  renderer: Renderer2;

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private rendererFactory: RendererFactory2
  ) {
    this.renderer = this.rendererFactory.createRenderer(null, null);
  }

  getDirection() {
    const htmlTag = this.document.getElementsByTagName("html")[0] as HTMLHtmlElement
    return htmlTag.dir
  }

  changeDirection(lang: string) {
    const htmlTag = this.document.getElementsByTagName("html")[0] as HTMLHtmlElement
    const isRtl = lang === "ar"
    htmlTag.lang = lang
    htmlTag.dir = isRtl ? "rtl" : "ltr"
    if (isRtl) { 
      this.setStyle('rtl', 'styles.ar.css')
      this.setStyle('bootstrapRtl', 'bootstrap.rtl.css', true)
      this.removeExistingStyle('bootstrapLtr')
    } else {
      this.setStyle('bootstrapLtr', 'bootstrap.ltr.css', true)
      this.removeExistingStyle('rtl')
      this.removeExistingStyle('bootstrapRtl')
    }
  }

  setStyle(cssTagId: string, cssFile: string, insertAtFirst = false) {
    this.removeExistingStyle(cssTagId);

    // Create a link element via Angular's renderer to avoid SSR troubles
    const element = this.renderer.createElement('link') as HTMLLinkElement;

    // Set type of the link item and path to the css file
    this.renderer.setProperty(element, 'id', cssTagId);
    this.renderer.setProperty(element, 'href', cssFile);
    this.renderer.setProperty(element, 'rel', 'stylesheet');

    // Add the style to the head section
    if (insertAtFirst) {
      var firstLink = this.document.querySelector('link')
      this.renderer.insertBefore(this.document.head, element, firstLink)
    } else {
      this.renderer.appendChild(this.document.head, element);
    }
  }

  removeExistingStyle(cssTagId: string) {
    const element = this.document.getElementById(cssTagId);
    if (element) {
      this.renderer.removeChild(this.document.head, element);
    }
  }
}
