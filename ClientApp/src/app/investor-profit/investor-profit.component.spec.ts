import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestorProfitComponent } from './investor-profit.component';

describe('InvestorProfitComponent', () => {
  let component: InvestorProfitComponent;
  let fixture: ComponentFixture<InvestorProfitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvestorProfitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestorProfitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
