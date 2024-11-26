import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { provideRouter, RouterOutlet } from '@angular/router';
import { provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient, withFetch } from '@angular/common/http';

describe('AppComponent', () => {
    let component: AppComponent;
    let fixture: ComponentFixture<AppComponent>;
    let compiled: HTMLElement;
  
    beforeEach(async () => {
      await TestBed.configureTestingModule({
        imports: [ AppComponent],
        providers: [provideClientHydration(), provideHttpClient(withFetch(),), provideHttpClient()]
      }).compileComponents();
  
      fixture = TestBed.createComponent(AppComponent);
      component = fixture.componentInstance;
      compiled = fixture.nativeElement;
      fixture.detectChanges();
    });

    it('deve criar app', () => {
        fixture = TestBed.createComponent(AppComponent);
        const app = fixture.componentInstance;
        expect(app).toBeTruthy();
    })
  
    it('valor e prazo deve ser invalido', () => {
      // Simulando valores inválidos
      component.cdbForm.patchValue({
        valor: -1,
        prazo: 1
      });
      fixture.detectChanges();
  
      const button = compiled.querySelector('button');
      expect(component.cdbForm.valid).toBeFalse();
      expect(button?.hasAttribute('disabled')).toBeTrue();
    });
  
    it('deve retornar parametros de entrada esperados', () => {
      // Simulando valores válidos
      component.cdbForm.patchValue({
        valor: 1,
        prazo: 3
      });
      fixture.detectChanges();
  
      const button = compiled.querySelector('button');
      expect(component.cdbForm.valid).toBeTrue();
      expect(button?.hasAttribute('disabled')).toBeFalse();
    });
  
    it('deve submeter a pagina', () => {
      component.cdbForm.patchValue({
        valor: 15,
        prazo: 30
      });
      fixture.detectChanges();
      const button = compiled.querySelector('button') as HTMLButtonElement;

      expect(component.cdbForm.value.valor).toBe(15);
      expect(component.cdbForm.value.prazo).toBe(30);
      expect(component.cdbForm.valid).toBeTrue();
      expect(button.disabled).toBeFalse();
    });
  });