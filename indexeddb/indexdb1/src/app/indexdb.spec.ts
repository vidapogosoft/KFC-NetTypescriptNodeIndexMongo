import { TestBed } from '@angular/core/testing';

import { Indexdb } from './indexdb';

describe('Indexdb', () => {
  let service: Indexdb;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Indexdb);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
