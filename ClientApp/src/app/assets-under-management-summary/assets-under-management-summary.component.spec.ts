import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetsUnderManagementSummaryComponent } from './assets-under-management-summary.component';

describe('AssestsUnderManagementSummaryComponent', () => {
  let component: AssetsUnderManagementSummaryComponent;
  let fixture: ComponentFixture<AssetsUnderManagementSummaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssetsUnderManagementSummaryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssetsUnderManagementSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
